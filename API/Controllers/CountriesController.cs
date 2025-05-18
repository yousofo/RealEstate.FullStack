using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class CountriesController(IServicesManager manager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

        }
    }
}
