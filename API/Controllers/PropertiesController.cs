﻿using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Application.Dtos.Create;
using Microsoft.AspNetCore.Authorization;
namespace RealEstateFullStackApp.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PropertiesController(IPropertiesService propertyService) : ControllerBase
    {
        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            var props =await propertyService.GetAllAsync();
            return Ok(props);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyCDTO property)
        {
            return await propertyService.CreateAsync(property) ? Created() : BadRequest();
        }
    }
}
