using Application.Interfaces;
using Application.Interfaces.Repos;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repos.GenericRepos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork(ApplicationDbContext context,ILogger<UnitOfWork> logger) : IUnitOfWork
    {
        BaseRepo<Property> _properties;
        BaseRepo<Location> _locations;
        BaseRepo<Category> _categories;
        public IBaseRepo<Property> Properties
        {
            get
            {
                _properties ??= new BaseRepo<Property>(context, logger);
                return _properties;
            }
        }
        public IBaseRepo<Location> Locations
        {
            get
            {
                _locations ??= new BaseRepo<Location>(context, logger);
                return _locations;
            }
        }
        public IBaseRepo<Category> Categories
        {
            get
            {
                _categories ??= new BaseRepo<Category>(context, logger);
                return _categories;
            }
        }


        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
