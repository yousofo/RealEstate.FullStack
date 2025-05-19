using Application.Dtos;
using Application.ReadOptions;
using Domain.Enums;
using Domain.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos.EntityRepos
{
    public interface ILocationsViewRepo
    {
        public Task<IEnumerable<LocationView>> GetAllAsync(CancellationToken cancellationToken );
        public IQueryable<LocationView> GetAllQuery(PaginatedSearchReq searchReq );
        public Task<PaginatedRes<LocationView>> GetPageAsync(PaginatedSearchReq searchReq, CancellationToken cancellationToken);
    }
}
