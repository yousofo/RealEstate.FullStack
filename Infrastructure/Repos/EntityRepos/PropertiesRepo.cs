using Application.Dtos;
using Application.Dtos.Request;
using Application.Interfaces.Repos.EntityRepos;
using Application.ReadOptions;
using Domain.Enums;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos.EntityRepos
{
    public class PropertiesRepo(ApplicationDbContext context, ILogger logger) : BaseRepo<Property>(context, logger), IPropertiesRepo
    {
        public async Task<PaginatedRes<Property>> GetPageAsync(PaginatedSearchReq searchReq, LocationReq? location, DeletionType deletionType, bool trackChanges = false)
        {
            var query = GetAllQuery(searchReq, deletionType, trackChanges);

            if (location is not null)
            {
                query = query
                    .Where(p => p.Country.Name.Contains(location.CountryName ) &&
                                p.Region.Name.Contains(location.RegionName ) &&
                                p.City.Name.Contains(location.CityName ));
            };

            query.Include(p => p.Category)
            .Include(p => p.Album.Images)
            .Include(p => p.Album.Videos)
            .Include(p => p.City)
            .Include(p => p.Region)
            .Include(p => p.Country);
            //.Include(p => p.City.Region.Country)


            var pageItems = await query
                .Skip((searchReq.PageNumber - 1) * searchReq.PageSize)
                .Take(searchReq.PageSize)
                .ToListAsync();


            var paginatedRes = new PaginatedRes<Property>
            {
                PageNumber = searchReq.PageNumber,
                PageSize = searchReq.PageSize,
                TotalCount = await query.CountAsync(),
                Items = pageItems
            };

            return paginatedRes;

        }




        public override async Task<bool> AddAsync(Property property, bool trackChanges = false)
        {
            try
            {
                context.Add(property);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("generic repo add exception", ex.Message, ex);
                return false;
            }

        }


    }
}
