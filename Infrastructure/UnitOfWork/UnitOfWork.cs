using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repos.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork(ApplicationDbContext context)
    {
        BaseRepo<Property> _properties;
        BaseRepo<Location> _locations;
        BaseRepo<Category> _categories;
        public BaseRepo<Property> Properties
        {
            get
            {
                _properties ??= new BaseRepo<Property>(context);
                return _properties;
            }
        }
        public BaseRepo<Location> Locations
        {
            get
            {
                _locations ??= new BaseRepo<Location>(context);
                return _locations;
            }
        }
        public BaseRepo<Category> Categories
        {
            get
            {
                _categories ??= new BaseRepo<Category>(context);
                return _categories;
            }
        }


        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
