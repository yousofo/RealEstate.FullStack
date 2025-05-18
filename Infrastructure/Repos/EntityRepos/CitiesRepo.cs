using Application.Dtos;
using Application.Interfaces.Repos.EntityRepos;
using Application.ReadOptions;
using Domain.Enums;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos.EntityRepos
{
    public class CitiesRepo(ApplicationDbContext context, ILogger logger) : BaseRepo<City>(context, logger), ICitiesRepo
    {
         
    }
}
