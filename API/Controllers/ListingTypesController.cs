using Application.Dtos.Create;
using Application.Interfaces.Services;
using Application.ReadOptions;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListingTypesController(IServicesManager manager) : ControllerBase
    {
        [HttpGet]
        [OutputCache(PolicyName = "Duration")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var props = await manager.PropertyListingTypes.GetAllAsync(cancellationToken);
            return Ok(props);
        }






        [HttpPost("")]
        //[Authorize(Roles ="Owner, Admin")]
        public async Task<IActionResult> Create(PropertyListingTypeCDTO dto)
        {
             var result = await manager.PropertyListingTypes.AddAsync(dto);
            if (result.IsSuccess)
            {
                return Created("/", result);
            }

            return BadRequest(result);
        }

    }
}
