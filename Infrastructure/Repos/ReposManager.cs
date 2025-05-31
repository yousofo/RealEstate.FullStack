using Application.Interfaces.Repos;
using Application.Interfaces.Repos.EntityRepos;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repos.EntityRepos;
using Infrastructure.Repos.ViewRepos;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class ReposManager(ApplicationDbContext context, ILogger<ReposManager> logger, UserManager<AppUser> userManager, IConfiguration configuration) : IReposManager
    {
        Lazy<PropertiesRepo> _properties = new(() => new(context, logger));
        Lazy<CategoriesRepo> _categories = new(() => new(context, logger));
        Lazy<CountriesRepo> _countries = new(() => new(context, logger));
         Lazy<CitiesRepo> _cities = new(() => new(context, logger));
         Lazy<RegionsRepo> _regions = new(() => new(context, logger));
        Lazy<AuthRepo> _auth = new(() => new (userManager, new JwtProvider(configuration)));
        Lazy<LocationsViewRepo> _locationView = new(() => new (context, logger));
        



        public IPropertiesRepo Properties => _properties.Value;
        public ICategoriesRepo Categories => _categories.Value;
        public IRegionsRepo Regions => _regions.Value;
        public ICountriesRepo Countries => _countries.Value;
         public ICitiesRepo Cities => _cities.Value;
        public IAuthRepo Auth => _auth.Value;
        public ILocationsViewRepo LocationsView => _locationView.Value;




        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
