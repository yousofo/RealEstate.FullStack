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
using Application.Interfaces.Services;

namespace Application.Services
{
    public class BaseService<T, RDTO, CDTO, UDTO>(IBaseRepo<T> repo, IMapper mapper) : IBaseService<RDTO, CDTO, UDTO> where T : class
    {

        public async Task<IEnumerable<RDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var models = await repo.GetAllAsync(cancellationToken);

            if (typeof(T) == typeof(RDTO))
            {
                return models.Cast<RDTO>();
            }

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
            };

            if (typeof(T) != typeof(RDTO))
            {
                dtosPage.Items = mapper.Map<IEnumerable<RDTO>>(modelsPage.Items);
            }


            return dtosPage;

        }



        public virtual async Task<Result> AddAsync(CDTO dto)
        {
            var entity = mapper.Map<T>(dto);
            var isAdded = await repo.AddAsync(entity);
            if(isAdded)
            {
                return new Result(true, null);
            }

            return new Result(false, new("","couldn't create"));
        }

        public bool IsSameType(Type o1, Type o2)
        {
            return o1 == o2;
        }

        public Task<Result> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
