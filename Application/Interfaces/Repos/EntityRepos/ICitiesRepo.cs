using Application.Interfaces.Repos.GenericRepos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos.EntityRepos
{
    public interface ICitiesRepo: IBaseRepo<City>
    {
    }
}
