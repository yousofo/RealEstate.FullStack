using Application.Interfaces.Repos.EntityRepos;
using Infrastructure.Data;
using Infrastructure.Repos.GenericRepos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos.EntityRepos
{
    public class CountriesRepo(ApplicationDbContext context, ILogger logger) : BaseRepo<Country>(context, logger), ICountriesRepo
    {
    }
}
