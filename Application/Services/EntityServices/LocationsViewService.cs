using Application.Interfaces.Repos;
using Application.Interfaces.Services;
using Application.Interfaces.Services.EntityServices;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class LocationsViewService(IReposManager manager,IMapper mapper) :
        BaseService<LocationView, LocationView, LocationView, LocationView>(manager,mapper), ILocationsViewService
    {
    }
}
