using Application.Interfaces.Repos.EntityRepos;
using Application.Interfaces.Services.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IServicesManager
    {
        public IPropertiesService Properties{ get; }
        public ICategoriesService Categories{get;}
        public ICountriesService Countries{get;}
        public IStatesService States{get;}
        public ICitiesService Cities{get;}
        public IAuthService Auth{get;}
    }
}
