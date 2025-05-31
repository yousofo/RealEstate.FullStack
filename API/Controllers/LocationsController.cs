using Application.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.IO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController(HttpClient httpClient,IConfiguration configuration): ControllerBase
    {
        //ThirdPartyServices/LocationIQService.

        [HttpGet("{query}")]
        public async Task<IActionResult> GetByQuery(string query)
        {
            var apiKey = configuration["LocationIQToken"];
            var response = await httpClient.GetAsync($"https://api.locationiq.com/v1/autocomplete?key={apiKey}&q={query}&format=json");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error fetching data from LocationIQ");
            }
            var data = await response.Content.ReadFromJsonAsync(typeof(List<LocationRes>));
            return Ok(data);
            //return new FileStreamResult(data, "application/json");

        }
    }
}
