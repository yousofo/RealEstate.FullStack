using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Dtos.Update;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.EntityServices
{
    public interface IPropertyListingTypesService : IBaseService<PropertyListingTypeRDTO, PropertyListingTypeCDTO, PropertyListingTypeUDTO>
    {
    }
}
