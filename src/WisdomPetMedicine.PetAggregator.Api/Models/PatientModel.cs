namespace WisdomPetMedicine.PetAggregator.Api.Models;

public record PatientModel(Guid Id, string BloodType, decimal? Weight, string Status);