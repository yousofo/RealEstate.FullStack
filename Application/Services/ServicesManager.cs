using Application.Interfaces.Repos;
using Application.Interfaces.Repos.EntityRepos;
using Application.Interfaces.Services;
using Application.Interfaces.Services.EntityServices;
using Application.Interfaces.Services.ViewServices;
using Application.Services.EntityServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServicesManager(IReposManager reposManager,IHttpContextAccessor httpContextAccessor, IMapper mapper) : IServicesManager
    {
        Lazy<PropertiesService> _properties = new(() => new(reposManager, mapper));
        Lazy<CategoriesService> _categories = new(() => new(reposManager, mapper));
        Lazy<CountriesService> _countries = new(() => new(reposManager, mapper));
        Lazy<StatesService> _states = new(() => new(reposManager, mapper));
        Lazy<CitiesService> _cities = new(() => new(reposManager, mapper));
        Lazy<LocationsViewService> _locationsView = new(() => new(reposManager, mapper));
        Lazy<PropertyListingTypesService> _propertyListingTypesService = new(() => new(reposManager, mapper));
        Lazy<AuthService> _auth = new(() => new(reposManager.Auth));


        public IHttpContextAccessor HttpContextAccessor=> httpContextAccessor;
        public IPropertiesService Properties => _properties.Value;
        public ICategoriesService Categories => _categories.Value;
        public ICountriesService Countries => _countries.Value;
        public IStatesService States => _states.Value;
        public ICitiesService Cities => _cities.Value;
        public IPropertyListingTypesService PropertyListingTypes => _propertyListingTypesService.Value;
        public IAuthService Auth => _auth.Value;

        public ILocationsViewService LocationsView => _locationsView.Value;
    }
}
