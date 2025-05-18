using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Interfaces.Repos;
using Application.Interfaces.Services;
using Application.Interfaces.Services.EntityServices;
using Application.ReadOptions;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class CountriesService(IReposManager manager, IMapper mapper) : BaseService<Country, CountryRDTO, CountryCDTO, CountryRDTO>(manager.Countries, mapper), ICountriesService
    {
         
    }
}
