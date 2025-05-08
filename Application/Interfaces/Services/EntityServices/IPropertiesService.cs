using Application.Dtos;
using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.ReadOptions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.EntityServices
{
    public interface IPropertiesService
    {
        public Task<IEnumerable<PropertyRDTO>> GetAllAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges =false, CancellationToken cancellationToken = default);
        
        public Task<PaginatedRes<PropertyRDTO>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges = false, CancellationToken cancellationToken = default);
        Task<bool> CreateAsync(PropertyCDTO property);
    }
}
