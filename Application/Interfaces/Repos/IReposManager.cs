using Application.Interfaces.Repos.EntityRepos;
using Domain.Models;
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
        public ICategoriesRepo Categories{get;}
        public ICountriesRepo Countries{get;}
         public ICitiesRepo Cities{get;}
        public IAuthRepo Auth{get;}
        public ILocationsViewRepo LocationsView{get;}


        Task SaveAsync();
    }
}
