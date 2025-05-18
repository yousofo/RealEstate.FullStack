using Application.Dtos;
using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Interfaces.Repos;
using Application.Interfaces.Services.EntityServices;
using Application.ReadOptions;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class PropertiesService(IReposManager manager, IMapper mapper) : BaseService<Property, PropertyRDTO>(manager.Properties, mapper), IPropertiesService
    {
        public async Task<Result> CreateAsync(PropertyCDTO property)
        {
            var prop = mapper.Map<Property>(property);
            prop.Thumbnail = "test link";
            bool isAdded = await manager.Properties.AddAsync(prop);
            return new Result(isAdded,new ("",""));
        }
    }
}
