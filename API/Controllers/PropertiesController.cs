using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Application.Dtos.Create;
using Microsoft.AspNetCore.Authorization;
using Application.Interfaces.Services.EntityServices;
using Application.Interfaces.Services;
namespace RealEstateFullStackApp.Server.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class PropertiesController(IServicesManager manager,ILogger<PropertiesController> logger) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var props =await manager.Properties.GetAllAsync();
            logger.LogInformation("Properties retrieved");
            return Ok(props);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(PropertyCDTO property)
        {
            return await manager.Properties.CreateAsync(property) ? Created() : BadRequest();
        }
    }
}
