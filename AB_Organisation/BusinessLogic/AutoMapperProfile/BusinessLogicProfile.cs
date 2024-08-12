using AutoMapper;
using Common.Dto;
using Common.Models;
using DataAccess.Entities;

namespace BusinessLayer.AutoMapperProfile;

public class BusinessLogicProfile : Profile
{
    public BusinessLogicProfile()
    {
        CreateMap<Organisation, OrganisationDto>();
        CreateMap<OrganisationDto, Organisation>();

        CreateMap<GetPremisesModel, Premise>();
        CreateMap<Premise, GetPremisesModel>();
    }
}
