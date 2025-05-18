using Application.Dtos;
using Application.Dtos.Create;
using Application.Interfaces.Services;
using Application.ReadOptions;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController(IServicesManager manager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll( CancellationToken cancellationToken = default)
        {
            var countries = await manager.Countries.GetAllAsync( cancellationToken);
            return Ok(countries);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Create(CountryCDTO cDTO)
        {
            var result = await manager.Countries.CreateAsync(cDTO);

            if (result.IsSuccess)
            {
                return Created("/", result);
            }
            return BadRequest(result);
        }
    }
}
