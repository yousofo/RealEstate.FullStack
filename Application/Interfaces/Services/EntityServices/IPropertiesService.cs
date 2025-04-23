using Application.Dtos.Create;
using Application.Dtos.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.EntityServices
{
    public interface IPropertiesService
    {
        public Task<IEnumerable<PropertyRDTO>> GetAllAsync(int? pageNumber);
        Task<bool> CreateAsync(PropertyCDTO property);
    }
}
