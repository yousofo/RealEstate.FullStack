using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Application.Dtos.Create;
using Microsoft.AspNetCore.Authorization;
using Application.Interfaces.Services.EntityServices;
using Application.Interfaces.Services;
using Application.Dtos.Read;
using Microsoft.Extensions.Logging;
namespace RealEstateFullStackApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController(IServicesManager manager,ILogger<PropertiesController> logger) : ControllerBase
    {
        [HttpGet("")]
        //[Authorize]
        public async Task<IActionResult> GetAll([FromQuery]int? pageNumber)
        {
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                var cookie = Request.Cookies.ElementAt(i);
                logger.LogTrace($"{cookie.Key} : {cookie.Value}");
            }
            logger.LogInformation(Request.Cookies.Count.ToString());
            //var props =await manager.Properties.GetAllAsync(pageNumber);
            logger.LogInformation("Properties retrieved");
            return Ok(new PropertyRDTO[1]);
        }



        [HttpGet("page/{pageNumber:int}")]
        public async Task<IActionResult> GetPage([FromRoute] int pageNumber)
        {
            
            var props = await manager.Properties.GetAllAsync(pageNumber);
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
