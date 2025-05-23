﻿using Application.ReadOptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController():ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }


        [HttpGet("page")]
        public async Task<IActionResult> GetPage([FromQuery] PaginatedSearchReq searchReq)
        {
            throw new NotImplementedException();
        }


        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] object categoryCDTO)
        {
            throw new NotImplementedException();
        }



        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] object categoryUDTO)
        {
            throw new NotImplementedException();
        }



        
        [HttpPost("assign")]
        public async Task<IActionResult> Assign([FromBody] object userRole)
        {
            //note: only 1 category per property
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
