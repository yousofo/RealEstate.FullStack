using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Interfaces.Repos;
using Application.Interfaces.Services.EntityServices;
using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class PropertiesService(IReposManager manager, IMapper mapper) : IPropertiesService
    {
        public async Task<bool> CreateAsync(PropertyCDTO property)
        {
            var prop = mapper.Map<Property>(property);
            prop.PreviewImageLink = "test link";
            bool isAdded = await manager.Properties.AddAsync(prop);
            return isAdded;
        }

        public async Task<IEnumerable<PropertyRDTO>> GetAllAsync(int? pageNumber)
        {
            var allProps = await manager.Properties.GetAllQuery(pageNumber).ToListAsync();
            return mapper.Map<IEnumerable<PropertyRDTO>>(allProps);
        }

        public async Task<IEnumerable<PropertyRDTO>> GetPageAsync(int pageNumber,int pageSize=20)
        {
            var allProps = await manager.Properties.GetPageQuery(pageNumber, pageSize).ToListAsync();
            return mapper.Map<IEnumerable<PropertyRDTO>>(allProps);
        }
    }
}
