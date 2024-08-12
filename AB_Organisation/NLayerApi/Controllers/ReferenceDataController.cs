using BusinessLayer.Interfaces;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace NLayerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReferenceDataController(IReferenceDataService referenceDataService) : ControllerBase
{
    // Get by code --> list value
    [HttpGet("{code}")]
    public async Task<ActionResult<ReferenceDataDto>> GetRefValuesByCode(string code)
    {
        var referenceDataDto = await referenceDataService.GetRefValuesByCodeAsync(code);

        if (referenceDataDto == null)
        {
            return Content("No data");
        }
        return Ok(referenceDataDto);
    }
}