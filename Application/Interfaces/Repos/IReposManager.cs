using Application.Interfaces.Repos.EntityRepos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IReposManager
    {
        public IPropertiesRepo Properties{ get; }
        public IPropertyListingTypesRepo PropertyListingTypes{ get; }
        public IHttpContextAccessor HttpContextAccessor { get; }
        public ICategoriesRepo Categories{get;}
        public ICountriesRepo Countries{get;}
         public ICitiesRepo Cities{get;}
        public IRegionsRepo Regions{get;}
        public IAuthRepo Auth{get;}
        public ILocationsViewRepo LocationsView{get;}


        Task SaveAsync();
    }
}
