namespace WisdomPetMedicine.PetAggregator.Api.Models;

public class StateModel
{
    public DateTime LastQuery { get; set; }
    public IEnumerable<dynamic> Data { get; set; }
}