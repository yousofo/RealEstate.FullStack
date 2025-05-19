using Application.Dtos;
using Application.Interfaces.Repos;
using Application.Interfaces.Services;
using Application.Interfaces.Services.ViewServices;
using Application.ReadOptions;
using AutoMapper;
using Domain.Enums;
using Domain.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class LocationsViewService(IReposManager manager,IMapper mapper): ILocationsViewService
    {
        public async Task<IEnumerable<LocationView>> GetAllAsync(CancellationToken cancellationToken)
        {
            var models = await manager.LocationsView.GetAllAsync(cancellationToken);

            return models;


        }

        public async Task<PaginatedRes<LocationView>> GetPageAsync(PaginatedSearchReq searchReq , CancellationToken cancellationToken  )
        {
            var modelsPage = await manager.LocationsView.GetPageAsync(searchReq, cancellationToken);

            return modelsPage;

        }
    }
}
