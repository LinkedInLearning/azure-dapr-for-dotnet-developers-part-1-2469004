using Dapr;
using Microsoft.AspNetCore.Mvc;
using WisdomPetMedicine.Hospital.Api.Infrastructure;
using WisdomPetMedicine.Hospital.Api.IntegrationEvents;
using WisdomPetMedicine.Hospital.Domain.Entities;
using WisdomPetMedicine.Hospital.Domain.Repositories;
using WisdomPetMedicine.Hospital.Domain.ValueObjects;

namespace WisdomPetMedicine.Hospital.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class IntegrationEventsController : ControllerBase
{
    private readonly IServiceScopeFactory serviceScopeFactory;
    private readonly IPatientAggregateStore patientAggregateStore;
    private readonly ILogger<IntegrationEventsController> logger;

    public IntegrationEventsController(IServiceScopeFactory serviceScopeFactory,
                                       IPatientAggregateStore patientAggregateStore,
                                       ILogger<IntegrationEventsController> logger)
    {
        this.serviceScopeFactory = serviceScopeFactory;
        this.patientAggregateStore = patientAggregateStore;
        this.logger = logger;
    }

    [Topic("pubsub", "pet-transferred-to-hospital")]
    public async Task<IActionResult> OnPetTransferredToHospital(PetTransferredToHospitalIntegrationEvent theEvent)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();

        var existingPatient = await dbContext.PatientsMetadata.FindAsync(theEvent.Id);
        if (existingPatient == null)
        {
            dbContext.PatientsMetadata.Add(theEvent);
            await dbContext.SaveChangesAsync();
        }

        var patientId = PatientId.Create(theEvent.Id);
        var patient = new Patient(patientId);
        await patientAggregateStore.SaveAsync(patient);

        var message = $"Pet transferred to hospital: {theEvent.Id}";
        logger?.LogInformation(message);

        return Ok(message);
    }
}