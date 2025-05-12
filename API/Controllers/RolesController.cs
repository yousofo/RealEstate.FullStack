using Application.ReadOptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin,Owner")]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }




        [HttpGet("page")]
        public async Task<IActionResult> GetPage([FromQuery] PaginatedSearchReq searchReq)
        {
            throw new NotImplementedException();
        }


        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] object roleCDTO)
        {
            throw new NotImplementedException();
        }



        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] object roleUDTO)
        {
            throw new NotImplementedException();
        }




        [HttpPost("assign")]
        public async Task<IActionResult> Assign([FromBody] object userRole)
        {
            throw new NotImplementedException();
        }


        [HttpPost("unassign")]
        public async Task<IActionResult> Unassign([FromBody] object userRole)
        {
            throw new NotImplementedException();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            throw new NotImplementedException();
        }
    }
}
