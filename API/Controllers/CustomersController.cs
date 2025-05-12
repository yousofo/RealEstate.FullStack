using Application.ReadOptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController:ControllerBase
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


        //might not need, just leave in case
        //[HttpPost("")]
        //public async Task<IActionResult> Create([FromBody] object customerCDTO)
        //{
        //    throw new NotImplementedException();
        //}



        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] object customerUDTO)
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
