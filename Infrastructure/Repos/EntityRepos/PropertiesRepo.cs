using Application.Interfaces.Repos.EntityRepos;
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
    public class PropertiesRepo(ApplicationDbContext context, ILogger logger) : BaseRepo<Property>(context, logger),IPropertiesRepo
    {
        public override IQueryable<Property> GetAllQuery()
        {
            return context.Properties
                .Include(p => p.Categories)
                .Include(p => p.ImageLinks)
                .Select(p => new Property
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    Description = p.Description,
                    PreviewImageLink = p.PreviewImageLink,
                    Status = p.Status,
                    AddressDescription = p.AddressDescription,
                    Location = new Location
                    {
                        Country = p.City.State.Country.Name,
                        State = p.City.State.Name,
                        City = p.City.Name,
                    },
                    ImageLinks = p.ImageLinks,
                    CityId = p.CityId,
                    City = p.City,
                    Categories = p.Categories,
                }).AsQueryable();
        }
        public override IQueryable<Property> GetPageQuery(int pageNumber, int pageSize = 20)
        {
            return context.Properties
                .Include(p => p.Categories)
                .Include(p => p.ImageLinks)
                .Select(p => new Property
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    Description = p.Description,
                    PreviewImageLink = p.PreviewImageLink,
                    Status = p.Status,
                    AddressDescription = p.AddressDescription,
                    Location = new Location {
                        Country = p.City.State.Country.Name,
                        State = p.City.State.Name,
                        City = p.City.Name,
                    },
                    ImageLinks = p.ImageLinks,
                    CityId = p.CityId,
                    City = p.City,
                    Categories = p.Categories,
                })
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .AsQueryable();
        }
    }
}
