namespace WisdomPetMedicine.Hospital.Api.Commands;

public record AddProcedureCommand(Guid Id, string Procedure);
public record AdmitPatientCommand(Guid Id);
public record DischargePatientCommand(Guid Id);
public record SetBloodTypeCommand(Guid Id, string BloodType);
public record SetWeightCommand(Guid Id, decimal Weight);
