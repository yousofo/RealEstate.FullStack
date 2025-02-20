using Application.Interfaces.Repos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepo<Property> Properties {  get; }
        IBaseRepo<Location> Locations {  get; }
        IBaseRepo<Category> Categories{ get; }


        Task SaveAsync();
    }
}
