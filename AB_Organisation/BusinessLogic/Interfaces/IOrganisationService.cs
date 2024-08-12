using Common.Dto;
using Common.Helper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace BusinessLayer.Interfaces
{
    public interface IOrganisationService
    {
        Task<PagedList<OrganisationDto>> GetOrganisationAsync(OrganisationParams organisationParams);


        Task<List<GetPremisesModel>> GetOrganisationPremisesAsync(int id);
    }
}
