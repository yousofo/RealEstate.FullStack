using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Dtos;
using Application.ReadOptions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IBaseService<RDTO,CDTO,UDTO>
    {
        public Task<IEnumerable<RDTO>> GetAllAsync( CancellationToken cancellationToken  );

        public Task<PaginatedRes<RDTO>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges = false, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(CDTO property);
    }
}
