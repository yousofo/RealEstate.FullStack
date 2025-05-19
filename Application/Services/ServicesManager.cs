using Application.Interfaces.Repos;
using Application.Interfaces.Repos.EntityRepos;
using Application.Interfaces.Services;
using Application.Interfaces.Services.EntityServices;
using Application.Interfaces.Services.ViewServices;
using Application.Services.EntityServices;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServicesManager(IReposManager reposManager, IMapper mapper): IServicesManager
    {
        Lazy<IPropertiesService> _properties = new(() => new PropertiesService(reposManager, mapper));
        Lazy<ICategoriesService> _categories = new(() => new CategoriesService(reposManager, mapper));
        Lazy<ICountriesService> _countries = new(() => new CountriesService(reposManager, mapper));
        Lazy<IStatesService> _states = new(() => new StatesService(reposManager, mapper));
        Lazy<ICitiesService> _cities = new(() => new CitiesService(reposManager, mapper));
        Lazy<ILocationsViewService> _locationsView = new(() => new LocationsViewService(reposManager, mapper));
        Lazy<IAuthService> _auth= new(() => new AuthService(reposManager.Auth));



        public IPropertiesService Properties => _properties.Value;
        public ICategoriesService Categories => _categories.Value;
        public ICountriesService Countries => _countries.Value;
        public IStatesService States => _states.Value;
        public ICitiesService Cities => _cities.Value;
        public IAuthService Auth => _auth.Value;

        public ILocationsViewService LocationsView => _locationsView.Value;
    }
}
