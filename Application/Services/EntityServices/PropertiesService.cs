using Application.Dtos;
using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Dtos.Request;
using Application.Interfaces.Repos;
using Application.Interfaces.Services.EntityServices;
using Application.Options;
using Application.ReadOptions;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class PropertiesService(IReposManager manager, IMapper mapper) : BaseService<Property, PropertyRDTO, PropertyCDTO, PropertyRDTO>(manager.Properties, mapper), IPropertiesService
    {


        public async Task<PaginatedRes<PropertyRDTO>> GetPageAsync(PaginatedSearchReq searchReq, LocationReq? location, DeletionType deletionType, bool trackChanges = false, CancellationToken cancellationToken = default)
        {
            var modelsPage = await manager.Properties.GetPageAsync(searchReq, location, deletionType);

            var dtosPage = new PaginatedRes<PropertyRDTO>
            {
                PageNumber = modelsPage.PageNumber,
                PageSize = modelsPage.PageSize,
                TotalCount = modelsPage.TotalCount,
                Items = mapper.Map<IEnumerable<PropertyRDTO>>(modelsPage.Items)
            };



            return dtosPage;
        }




        public async Task<Result> AddAsync(PropertyCDTO dto)
        {
            var property = mapper.Map<Property>(dto);

            //listing types
            var listingTypes = await manager.PropertyListingTypes.DbSet.Where(l => dto.ListingTypesIds.Contains(l.Id)).ToListAsync();
            foreach (var type in listingTypes)
            {
                property.ListingTypes.Add(type);
            }

            //location
            var countryId = await manager.Countries.DbSet.Where(c => c.Name == dto.CountryName).Select(e => e.Id).FirstOrDefaultAsync();
            if (countryId == 0)
            {
                var country = new Country { Name = dto.CountryName };
                await manager.Countries.AddAsync(country);
                property.Country = country;

                if (dto.CityName is not null)
                {
                    var city = new City { Name = dto.CityName };
                    await manager.Cities.AddAsync(city);
                    property.City = city;
                }

                if (dto.RegionName is not null)
                {
                    var region = new Region { Name = dto.RegionName };
                    await manager.Regions.AddAsync(region);
                    property.Region = region;
                }
            }
            else
            {
                property.CountryId = countryId;

                var regionId = await manager.Regions.DbSet.Where(c => c.Name == dto.RegionName && c.CountryId == countryId).Select(e => e.Id).FirstOrDefaultAsync();
                if (regionId > 0) property.RegionId = regionId;

                var cityId = await manager.Cities.DbSet.Where(c => c.Name == dto.CityName && c.CountryId == countryId).Select(e => e.Id).FirstOrDefaultAsync();
                if (cityId > 0) property.CityId = cityId;
            }

            //owner
            property.OwnerId = manager.HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;


            var album = new Album { PropertyId = property.Id };
            await manager.Albums.AddAsync(album, true);

            //thumbnail
            var thumbnailLink = await FilesService.SaveAsync(dto.Thumbnail, FileType.Image);
            property.Thumbnail = thumbnailLink;

            //images
            foreach (var image in dto.Images)
            {
                var link = await FilesService.SaveAsync(image, FileType.Image);
                album.Images.Add(new Image { Title = image.FileName, Description = "property image description", Link = link });
            }

            bool isAdded = await manager.Properties.AddAsync(property);
            return new Result(isAdded, null);
        }




    }
}
