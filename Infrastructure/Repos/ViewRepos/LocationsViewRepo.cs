using Application.Dtos;
using Application.Interfaces.Repos.EntityRepos;
using Application.ReadOptions;
using Domain.Enums;
using Domain.Models.Views;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Infrastructure.Extensions;

namespace Infrastructure.Repos.ViewRepos
{
    public class LocationsViewRepo(ApplicationDbContext context, ILogger logger) :BaseViewRepo<LocationView>(context,logger), ILocationsViewRepo
    {
        
    }
}
