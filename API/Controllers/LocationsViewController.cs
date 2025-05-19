using Application.Interfaces.Services;
using Application.ReadOptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsViewController(IServicesManager manager):ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var locations = await manager.LocationsView.GetAllAsync(cancellationToken);
            return Ok(locations);
        }




        [HttpGet("page")]
        public async Task<IActionResult> GetPage([FromQuery]PaginatedSearchReq searchReq,CancellationToken cancellationToken)
        {
            var locations = await manager.LocationsView.GetPageAsync(searchReq, cancellationToken);
            return Ok(locations);
        }
    }
}
