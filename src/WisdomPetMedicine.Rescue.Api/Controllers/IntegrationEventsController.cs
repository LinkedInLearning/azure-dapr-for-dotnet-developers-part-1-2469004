using Dapr;
using Microsoft.AspNetCore.Mvc;
using WisdomPetMedicine.Rescue.Api.Infrastructure;
using WisdomPetMedicine.Rescue.Api.IntegrationEvents;
using WisdomPetMedicine.Rescue.Domain.Entities;
using WisdomPetMedicine.Rescue.Domain.Repositories;
using WisdomPetMedicine.Rescue.Domain.ValueObjects;

namespace WisdomPetMedicine.Rescue.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IntegrationEventsController : ControllerBase
{
    private readonly IServiceScopeFactory serviceScopeFactory;
    private readonly ILogger<IntegrationEventsController> logger;

    public IntegrationEventsController(IServiceScopeFactory serviceScopeFactory,
                                       ILogger<IntegrationEventsController> logger)
    {
        this.serviceScopeFactory = serviceScopeFactory;
        this.logger = logger;
    }

    [Topic("pubsub", "pet-flagged-for-adoption")]
    public async Task<IActionResult> OnPetFlaggedForAdoption(PetFlaggedForAdoptionIntegrationEvent theEvent)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRescueRepository>();
        var dbContext = scope.ServiceProvider.GetRequiredService<RescueDbContext>();
        dbContext.RescuedAnimalsMetadata.Add(theEvent);
        var rescuedAnimal = new RescuedAnimal(RescuedAnimalId.Create(theEvent.Id));
        await repo.AddRescuedAnimalAsync(rescuedAnimal);

        var message = $"Pet flagged for adoption: {theEvent.Id}";
        logger?.LogInformation(message);

        return Ok(message);
    }
}