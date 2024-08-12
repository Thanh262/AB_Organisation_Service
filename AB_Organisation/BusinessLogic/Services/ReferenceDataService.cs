using AutoMapper;
using BusinessLayer.Interfaces;
using Common.Dto;
using DataAccess;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services;

public class ReferenceDataService(DataContext context, IMapper mapper) : IReferenceDataService
{
    
    public async Task<ReferenceDataDto?> GetRefValuesByCodeAsync(string code)
    {
        var refCode = await context.RefCodes
            .Include(rc => rc.RefValues)
            .FirstOrDefaultAsync(rc => rc.Code == code);

        if (refCode == null)
        {
            return null;
        }

        return mapper.Map<ReferenceDataDto>(refCode);
    }
}