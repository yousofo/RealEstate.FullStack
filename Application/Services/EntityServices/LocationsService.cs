using Application.Interfaces.Repos;
using Application.Interfaces.Services.EntityServices;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class LocationsService(IReposManager manager) : ILocationsService
    {
        public async Task<(int countryId, int? regionId, int? cityId)> Get(string countryName, string? regionName, string? cityName)
        {
            var countryId = await manager.Countries.DbSet
                                .Where(c => c.Name == countryName)
                                .Select(r => r.Id)
                                .FirstOrDefaultAsync();

            if (countryId == 0)
            {
                var country = new Country { Name = countryName };
                await manager.Countries.AddAsync(country);
                await manager.SaveAsync();
                countryId = country.Id;
            }

            int? regionId = null;
            if (!string.IsNullOrWhiteSpace(regionName))
            {
                regionId = await manager.Regions.DbSet
                    .Where(r => r.Name == regionName && r.CountryId == countryId)
                    .Select(r => (int?)r.Id)
                    .FirstOrDefaultAsync();

                if (regionId == null)
                {
                    var region = new Region { Name = regionName, CountryId = countryId };
                    await manager.Regions.AddAsync(region);
                    await manager.SaveAsync();
                    regionId = region.Id;
                }
            }

            int? cityId = null;
            if (!string.IsNullOrWhiteSpace(cityName))
            {
                cityId = await manager.Cities.DbSet
                    .Where(c => c.Name == cityName && c.RegionId == regionId && c.CountryId == countryId)
                    .Select(c => (int?)c.Id)
                    .FirstOrDefaultAsync();

                if (cityId == null)
                {
                    var city = new City
                    {
                        Name = cityName,
                        RegionId = regionId,
                        CountryId = countryId
                    };
                    await manager.Cities.AddAsync(city);
                    await manager.SaveAsync();
                    cityId = city.Id;
                }
            }

            return (countryId, regionId, cityId);
        }
    }
}
