using BusinessLayer.Interfaces;
using Common.Dto;
using Common.Helper;
//using Common.Helper;
using BusinessLayer.Extensions;
using BusinessLayer.Services;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace NLayerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganisationsController : ControllerBase
    {
        private readonly IOrganisationService _organisationService;
        private readonly GeoLocationService _geoLocationService;

        public OrganisationsController(IOrganisationService organisationService, GeoLocationService geoLocationService)
        {
            _organisationService = organisationService;
            _geoLocationService = geoLocationService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<OrganisationDto>>> GetOrganisations([FromQuery] OrganisationParams organisationParams)
        {
            var organisations = await _organisationService.GetOrganisationAsync(organisationParams);

            Response.AddPaginationHeader(organisations.MetaData);

            return Ok(organisations);
        }

        [HttpGet("get premises")]
        public async Task<ActionResult<List<GetPremisesModel>>> GetOrganisationPremises(int id)
        {
            
            List<GetPremisesModel> premisesModels = await _organisationService.GetOrganisationPremisesAsync(id);
            
            return Ok(premisesModels);
        }

        [HttpGet("Get LocatedIn Info")]
        public async Task<ActionResult<GeoLocationModel>> GetLocatedIn(int postId)
        {
            var geoLocationInfo =await _geoLocationService.GetGeoLocation(postId);
            return geoLocationInfo;
        }
       
    }
}