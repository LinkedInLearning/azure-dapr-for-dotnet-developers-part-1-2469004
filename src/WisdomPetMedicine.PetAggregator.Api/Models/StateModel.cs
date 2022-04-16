namespace WisdomPetMedicine.PetAggregator.Api.Models;

public record StateModel(DateTime LastQuery, IEnumerable<dynamic> Data);