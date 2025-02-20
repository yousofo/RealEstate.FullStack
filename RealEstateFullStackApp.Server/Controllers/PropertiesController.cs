using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Application.Dtos.Create;
namespace RealEstateFullStackApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController(IPropertiesService propertyService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(propertyService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyCDTO property)
        {
            return await propertyService.CreateAsync(property) ? Created() : BadRequest();
        }
    }
}
