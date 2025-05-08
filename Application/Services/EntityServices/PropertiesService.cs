using Application.Dtos;
using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Interfaces.Repos;
using Application.Interfaces.Services.EntityServices;
using Application.ReadOptions;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class PropertiesService(IReposManager manager, IMapper mapper) : IPropertiesService
    {
        

        public async Task<IEnumerable<PropertyRDTO>> GetAllAsync(PaginatedSearchReq searchReq, DeletionType deletionType,bool trackChanges = false,CancellationToken cancellationToken=default)
        {
            
            var allProps = await manager.Properties.GetAllQuery(searchReq,deletionType).ToListAsync();

            return mapper.Map<IEnumerable<PropertyRDTO>>(allProps);
        }

        public async Task<PaginatedRes<PropertyRDTO>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges = false, CancellationToken cancellationToken = default)
        {
            var modelsPage = await manager.Properties.GetPageAsync(searchReq, deletionType);

            var dtosPage = new PaginatedRes<PropertyRDTO>
            {
                PageNumber = modelsPage.PageNumber,
                PageSize = modelsPage.PageSize,
                TotalCount = modelsPage.TotalCount,
                Items = mapper.Map<IEnumerable<PropertyRDTO>>(modelsPage.Items)
            };
 
            return dtosPage;
        }





        public async Task<bool> CreateAsync(PropertyCDTO property)
        {
            var prop = mapper.Map<Property>(property);
            prop.Thumbnail = "test link";
            bool isAdded = await manager.Properties.AddAsync(prop);
            return isAdded;
        }
    }
}
