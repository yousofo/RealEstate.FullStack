using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsViewController(IServicesManager manager):ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
            //var locations = manager
        }
    }
}
