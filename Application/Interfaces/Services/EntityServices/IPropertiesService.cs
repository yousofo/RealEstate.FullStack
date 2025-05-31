using Application.Dtos;
using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Dtos.Request;
using Application.ReadOptions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.EntityServices
{
    public interface IPropertiesService:IBaseService<PropertyRDTO, PropertyCDTO, PropertyCDTO>
    {
        public Task<PaginatedRes<PropertyRDTO>> GetPageAsync(PaginatedSearchReq searchReq,LocationReq location, DeletionType deletionType, bool trackChanges=false , CancellationToken cancellationToken = default);
     }
}
