using Application.Interfaces.Repos.EntityRepos;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos.EntityRepos
{
    public class StatesRepo(ApplicationDbContext context, ILogger logger) : BaseRepo<State>(context, logger)
        , IStatesRepo
    {
    }
}
