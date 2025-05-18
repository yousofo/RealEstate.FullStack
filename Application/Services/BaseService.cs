using Application.Dtos.Read;
using Application.Dtos;
using Application.ReadOptions;
using AutoMapper;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repos;

namespace Application.Services
{
    public class BaseService<T, RDTO>(IBaseRepo<T> repo, IMapper mapper) where T : class
    {

        public async Task<IEnumerable<RDTO>> GetAllAsync()
        {
            var models = await repo.GetAllAsync();

            return mapper.Map<IEnumerable<RDTO>>(models);
        }

        public async Task<PaginatedRes<RDTO>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges = false, CancellationToken cancellationToken = default)
        {
            var modelsPage = await repo.GetPageAsync(searchReq, deletionType);

            var dtosPage = new PaginatedRes<RDTO>
            {
                PageNumber = modelsPage.PageNumber,
                PageSize = modelsPage.PageSize,
                TotalCount = modelsPage.TotalCount,
                Items = mapper.Map<IEnumerable<RDTO>>(modelsPage.Items)
            };

            return dtosPage;
        }
    }
}
