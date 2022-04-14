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
        var pets = await daprClient.InvokeMethodAsync<IEnumerable<PetModel>>(HttpMethod.Get, "pet", "petquery");

        var rescues = await daprClient.InvokeMethodAsync<IEnumerable<RescueModel>>(HttpMethod.Get, "rescuequery", "rescuequery");

        var patients = await daprClient.InvokeMethodAsync<IEnumerable<PatientModel>>(HttpMethod.Get, "hospital", "patientquery");

        return Ok();
    }
}