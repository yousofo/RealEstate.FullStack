using Infrastructure.Data;
using Infrastructure.Repos.GenericRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos.EntityRepos
{
    internal class PropertiesRepo(ApplicationDbContext context, ILogger logger) : BaseRepo<Property>(context, logger)
    {
        public override IEnumerable<Property> GetPageQuery(int pageNumber, int pageSize = 20)
        {
            return context.Properties
                .Include(p=>p.Categories)
                .Include(p=>p.ImageLinks)
                .Include(p=>p.Location)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .AsQueryable();
        }
    }
}
