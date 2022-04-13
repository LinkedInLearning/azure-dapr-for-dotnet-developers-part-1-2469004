namespace WisdomPetMedicine.Rescue.Api.Commands;

public record ApproveAdoptionCommand(Guid PetId, Guid AdopterId);
public record CreateAdopterCommand(Guid Id, string Name, Questionnaire Questionnaire, Address Address);
public record Questionnaire(bool IsActivePerson, bool DoYouRent, bool HasFencedYard, bool HasChildren);
public record Address(string Street, string Number, string City, string PostalCode, string Country);
public record RejectAdoptionCommand(Guid PetId, Guid AdopterId);
public record RequestAdoptionCommand(Guid PetId, Guid AdopterId);
public record SetAdopterPhoneNumberCommand(Guid Id, string PhoneNumber);