using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Interfaces.Services;
using Application.ReadOptions;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(IServicesManager manager):ControllerBase
    {
        [HttpGet]
        //[Authorize(Roles = "Owner,Admin,Employee")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
 
             var categories = await manager.Categories.GetAllAsync(cancellationToken);
            return Ok(categories);
        }


        [HttpGet("listing-types")]
        public async Task<IActionResult> GetListingTypes([FromQuery] PaginatedSearchReq searchReq)
        {
            var listingTypes = new List<PropertyListingTypeRDTO>();
            return Ok();
        }


        [HttpPost("")]
        //[Authorize(Roles = "Owner,Admin,Employee")]

        public async Task<IActionResult> Create([FromBody] CategoryCDTO categoryCDTO)
        {
            var result = await manager.Categories.AddAsync(categoryCDTO);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPut("")]
        //[Authorize(Roles = "Owner,Admin,Employee")]

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
        //[Authorize(Roles = "Owner,Admin,Employee")]

        public async Task<IActionResult> Unassign([FromBody] object userRole)
        {
            throw new NotImplementedException();
        }



        [HttpDelete("{id}")]
        //[Authorize(Roles = "Owner,Admin,Employee")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ttt = await manager.Categories.DeleteAsync(id);
            return Ok(ttt);
        }
    }
}
