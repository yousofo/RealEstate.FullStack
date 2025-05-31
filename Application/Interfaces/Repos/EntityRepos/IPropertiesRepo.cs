using Application.Dtos;
using Application.Dtos.Request;
using Application.ReadOptions;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos.EntityRepos
{
    public interface IPropertiesRepo: IBaseRepo<Property>
    {
        public   Task<PaginatedRes<Property>> GetPageAsync(PaginatedSearchReq searchReq,LocationReq? location, DeletionType deletionType, bool trackChanges=false);

        //public PaginatedRes<Property> GetByLocation();
    }
}
