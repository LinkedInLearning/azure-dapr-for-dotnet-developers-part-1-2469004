using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using WisdomPetMedicine.PetAggregator.Api.Models;

namespace WisdomPetMedicine.PetAggregator.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PetAggregatorController : ControllerBase
{
    private readonly DaprClient daprClient;

    public PetAggregatorController(DaprClient daprClient)
    {
        this.daprClient = daprClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lastQuery = await daprClient.GetStateEntryAsync<StateModel>("statestore", "lastquery");
        if (lastQuery.Value != null && DateTime.UtcNow <= lastQuery.Value.LastQuery.AddSeconds(30))
        {
            return Ok(lastQuery.Value.Data);
        }

        IEnumerable<dynamic> result;
        result = await QueryPets();

        bool saved = false;
        while (!saved)
        {
            result = await QueryPets();
            lastQuery.Value = new StateModel()
            {
                LastQuery = DateTime.UtcNow,
                Data = result
            };
            saved = await lastQuery.TrySaveAsync();
        }

        return Ok(result);
    }
    
    private async Task<IEnumerable<dynamic>> QueryPets()
    {
        var pets = await daprClient.InvokeMethodAsync<IEnumerable<PetModel>>(HttpMethod.Get, "pet", "petquery");

        var rescues = await daprClient.InvokeMethodAsync<IEnumerable<RescueModel>>(HttpMethod.Get, "rescuequery", "rescuequery");

        var patients = await daprClient.InvokeMethodAsync<IEnumerable<PatientModel>>(HttpMethod.Get, "hospital", "patientquery");

        var result = from pet in pets
                     join patient in patients on pet.Id equals patient.Id
                     join rescue in rescues on pet.Id equals rescue.Id
                     select new
                     {
                         pet.Id,
                         pet.Name,
                         pet.Breed,
                         pet.Sex,
                         pet.Color,
                         pet.DateOfBirth,
                         pet.Species,
                         Hospital = new
                         {
                             patient.BloodType,
                             patient.Weight,
                             patient.Status,
                         },
                         Rescue = new
                         {
                             rescue.AdopterId,
                             rescue.AdopterName,
                             rescue.AdoptionStatus
                         }
                     };
        return result;
    }
}