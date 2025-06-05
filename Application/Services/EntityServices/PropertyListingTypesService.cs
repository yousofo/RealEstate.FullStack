using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Dtos.Update;
using Application.Interfaces.Repos;
using Application.Interfaces.Services.EntityServices;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class PropertyListingTypesService(IReposManager manager, IMapper mapper) : BaseService<PropertyListingType, PropertyListingTypeRDTO, PropertyListingTypeCDTO, PropertyListingTypeUDTO>(manager.PropertyListingTypes, mapper), IPropertyListingTypesService
    {
    }
}
