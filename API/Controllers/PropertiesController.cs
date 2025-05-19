using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Application.Dtos.Create;
using Microsoft.AspNetCore.Authorization;
using Application.Interfaces.Services.EntityServices;
using Application.Interfaces.Services;
using Application.Dtos.Read;
using Microsoft.Extensions.Logging;
using Application.ReadOptions;
using Domain.Enums;
using Microsoft.AspNetCore.OutputCaching;
namespace RealEstateFullStackApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController(IServicesManager manager, ILogger<PropertiesController> logger) : ControllerBase
    {
        [HttpGet("")]
        //[Authorize]
        public async Task<IActionResult> GetAll( CancellationToken cancellationToken)
        {

            var props = await manager.Properties.GetAllAsync(cancellationToken);

            return Ok(props);
        }



        [HttpGet("page")]
        [OutputCache(PolicyName ="Duration")]
        public async Task<IActionResult> GetPage([FromQuery] PaginatedSearchReq searchReq)
        {

            var props = await manager.Properties.GetPageAsync(searchReq, DeletionType.All);
            logger.LogInformation("Properties retrieved");
            return Ok(props);
        }



        [HttpPost("")]
        //[Authorize]
        public async Task<IActionResult> Create(PropertyCDTO property)
        {
            //var user = User;
            var result = await manager.Properties.CreateAsync(property);
            if (result.IsSuccess)
            {
                return Created("/",result);
            }

            return BadRequest(result);
        }
    }
}
