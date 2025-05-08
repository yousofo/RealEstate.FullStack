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
namespace RealEstateFullStackApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController(IServicesManager manager,ILogger<PropertiesController> logger) : ControllerBase
    {
        [HttpGet("")]
        //[Authorize]
        public async Task<IActionResult> GetAll([FromQuery]PaginatedSearchReq searchReq)
        {
 
            var props =await manager.Properties.GetAllAsync(searchReq,DeletionType.All);

             return Ok(props);
        }



        [HttpGet("page/{pageNumber:int}")]
        public async Task<IActionResult> GetPage([FromQuery] PaginatedSearchReq searchReq)
        {
            
            var props = await manager.Properties.GetAllAsync(searchReq,DeletionType.NotDeleted);
            logger.LogInformation("Properties retrieved");
            return Ok(props);
        }



        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> Create(PropertyCDTO property)
        {
            return await manager.Properties.CreateAsync(property) ? Created() : BadRequest();
        }
    }
}
