using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class PropertiesService(IUnitOfWork unit, IMapper mapper) : IPropertiesService
    {
        public async Task<bool> CreateAsync(PropertyCDTO property)
        {
            var prop = mapper.Map<Property>(property);
            prop.PreviewImageLink = "test link";
            bool isAdded = await unit.Properties.AddAsync(prop);
            return isAdded;
        }

        public async Task<IEnumerable<PropertyRDTO>> GetAllAsync()
        {
            var allProps = await unit.Properties.GetAllAsync();
            return mapper.Map<IEnumerable<PropertyRDTO>>(allProps);
        }

        public async Task<IEnumerable<PropertyRDTO>> GetPageAsync(int pageNumber,int pageSize=20)
        {
            var allProps = await unit.Properties.GetPageAsync(pageNumber, pageSize);
            return mapper.Map<IEnumerable<PropertyRDTO>>(allProps);
        }
    }
}
