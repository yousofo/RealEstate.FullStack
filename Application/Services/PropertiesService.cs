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

namespace Application.Services
{
    public class PropertiesService(IUnitOfWork unit,IMapper mapper) : IPropertiesService
    {
        public async Task<bool> CreateAsync(PropertyCDTO property)
        {
            var prop = mapper.Map<Property>(property);
            return await unit.Properties.AddAsync(prop);
        }

        public IEnumerable<PropertyRDTO> GetAll()
        {
            var allProps = unit.Properties.GetAll();
            return  mapper.Map<IEnumerable<PropertyRDTO>>(allProps);
        }
    }
}
