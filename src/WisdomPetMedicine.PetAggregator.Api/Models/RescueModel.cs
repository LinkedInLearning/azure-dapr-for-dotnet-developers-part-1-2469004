namespace WisdomPetMedicine.PetAggregator.Api.Models;

public record RescueModel(Guid Id, Guid? AdopterId, string AdopterName, string AdoptionStatus);