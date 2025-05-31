using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.EntityServices
{
    public interface ILocationsService
    {
        public Task<(int countryId, int? regionId, int? cityId)> Get(string countryName, string? regionName, string? cityName);
    }
}
