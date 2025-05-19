using Application.Dtos;
using Application.ReadOptions;
using Domain.Models.Views;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Infrastructure.Extensions;

namespace Infrastructure.Repos
{
    public class BaseViewRepo<T>(ApplicationDbContext context, ILogger logger):IBaseViewRepo<T> where T : class
    {
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().ToListAsync(cancellationToken);
        }
        public virtual IQueryable<T> GetAllQuery(PaginatedSearchReq searchReq)
        {
            IQueryable<T> query = context.Set<T>();
            query = query.Search(searchReq.SearchTerm).Sort(searchReq.OrderBy);

            return query.AsNoTracking();
        }

        public virtual async Task<PaginatedRes<T>> GetPageAsync(PaginatedSearchReq searchReq, CancellationToken cancellationToken)
        {
            var query = GetAllQuery(searchReq);

            var pageItems = await query
                .Skip((searchReq.PageNumber - 1) * searchReq.PageSize)
                .Take(searchReq.PageSize)
                .ToListAsync();

            var paginatedRes = new PaginatedRes<T>
            {
                PageNumber = searchReq.PageNumber,
                PageSize = searchReq.PageSize,
                TotalCount = await query.CountAsync(cancellationToken),
                Items = pageItems
            };

            return paginatedRes;
        }
    }
}
