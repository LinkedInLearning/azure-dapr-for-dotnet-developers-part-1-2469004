namespace WisdomPetMedicine.PetAggregator.Api.Models;

public record PetModel(Guid Id, string Name, string Breed, string Sex, string Color, DateTime DateOfBirth, string Species);
