using AutoMapper;
using Common.Dto;
using DataAccess.Entities;

namespace BusinessLayer.AutoMapperProfile;

public class ReferenceDataProfile : Profile
{
    public ReferenceDataProfile()
    {
        CreateMap<RefCode, ReferenceDataDto>();
        CreateMap<RefValue, RefValueDto>();
    }
}