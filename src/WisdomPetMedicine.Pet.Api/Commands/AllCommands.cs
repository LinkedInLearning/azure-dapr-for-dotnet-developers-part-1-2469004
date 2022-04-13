namespace WisdomPetMedicine.Pet.Api.Commands;

public record CreatePetCommand(Guid Id, string Name, string Breed, int Sex, string Color, DateTime DateOfBirth, string Species);
public record FlagForAdoptionCommand(Guid Id);
public record SetBreedCommand(Guid Id, string Breed);
public record SetColorCommand(Guid Id, string Color);
public record SetDateOfBirthCommand(Guid Id, DateTime DateOfBirth);
public record SetNameCommand(Guid Id, string Name);
public record TransferToHospitalCommand(Guid Id);