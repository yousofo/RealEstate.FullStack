using Application.Dtos.Create;
using Application.Dtos.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPropertiesService
    {
        IEnumerable<PropertyRDTO> GetAll();
        Task<bool> CreateAsync(PropertyCDTO property);
    }
}
