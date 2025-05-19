using Application.Dtos;
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
        public override async Task<PaginatedRes<Property>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges = false)
        {
            var query = GetAllQuery(searchReq, deletionType, trackChanges)
                .Include(p => p.Category)
                .Include(p => p.Album.Images)
                .Include(p => p.Album.Videos)
                .Include(p => p.City)
                .Include(p => p.Region.Country);
                //.Include(p => p.City.State.Country)
                

            var pageItems = await query
                .Skip((searchReq.PageNumber - 1) * searchReq.PageSize)
                .Take(searchReq.PageSize)
                .ToListAsync();
            logger.LogError($"\n-----------------------------------------\n");
            logger.LogError($"{pageItems[0].Category.Title}");

            var paginatedRes = new PaginatedRes<Property>
            {
                PageNumber = searchReq.PageNumber,
                PageSize = searchReq.PageSize,
                TotalCount = await query.CountAsync(),
                Items = pageItems
            };

            return paginatedRes;

        }
    }
}
