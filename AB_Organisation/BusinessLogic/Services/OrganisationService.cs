using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLayer.Extensions;
using BusinessLayer.Interfaces;
using Common.Dto;
using Common.Helper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public OrganisationService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedList<OrganisationDto>> GetOrganisationAsync(OrganisationParams organisationParams)
        {
            var query = _context.Organisations
                .Search(organisationParams.SearchTerm)
                .AsQueryable();
            if(organisationParams.FirstTenPart)
            {
                query = query.TakeFirstTen();
            }

            if (!organisationParams.InActive)
            {
                query = query.Active(organisationParams.InActive);
            }

            var organisationsQuery = query.ProjectTo<OrganisationDto>(_mapper.ConfigurationProvider);

            return await PagedList<OrganisationDto>.ToPagedList(organisationsQuery, organisationParams.PageNumber, organisationParams.PageSize);
        }

        public async Task<List<GetPremisesModel>> GetOrganisationPremisesAsync(int id )
        {
            List<int> servicesIds = await _context.OrganisationServices
                .Where(s=>s.OrganisationId == id)
                .Select(s=>s.ServiceId)
                .ToListAsync();


            var premises = await _context.Premises
                .Where(s => servicesIds.Contains(s.ServiceId))
                .ToListAsync();

            return _mapper.Map<List<GetPremisesModel>>(premises);
        }
        
    }
}
