using Application.Dtos.Read;
using Application.Interfaces.Repos;
using Application.Interfaces.Services.EntityServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class CountriesService(IReposManager manager, IMapper mapper) : ICountriesService
    {
        public async Task<IEnumerable<CountryRDTO>> GetAllAsync()
        {
            var countries = await manager.Countries.GetAllAsync();

            return mapper.Map<IEnumerable<CountryRDTO>>(countries);
        }
    }
}
