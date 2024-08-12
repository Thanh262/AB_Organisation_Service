using Common.Dto;

namespace BusinessLayer.Interfaces;

public interface IReferenceDataService
{
    Task<ReferenceDataDto?> GetRefValuesByCodeAsync(string code);
}