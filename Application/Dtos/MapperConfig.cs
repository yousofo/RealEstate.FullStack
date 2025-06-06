using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Dtos.Update;
using AutoMapper;
using Domain.Auth;
using Domain.Models;
using Domain.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Property, PropertyRDTO>();
            CreateMap<Property, PropertyRDTO>().ForMember(dto => dto.Category,
                opt => opt.MapFrom(src => src.Category.Title));
            CreateMap<Property, PropertyRDTO>().ForMember(dto => dto.Location,
               opt => opt.MapFrom(src => MapUtils.MapLocation(src))
              );
            CreateMap<PropertyRDTO, Property>().ForMember(p => p.Owner,
                opt => opt.Ignore());
            //CreateMap<Property, PropertyRDTO>().ForMember(dto => dto.Owner,
            //    opt => opt.MapFrom(src => new OwnerRDTO { Id = src.OwnerId, FirstName = src.Owner.FirstName }));


            CreateMap<PropertyCDTO, Property>();
            CreateMap<PropertyCDTO, Property>().ForMember(e => e.ListingTypes, opts => opts.Ignore());


            CreateMap<Property, PropertyUDTO>();


            CreateMap<PropertyListingType, PropertyListingTypeRDTO>().ReverseMap();
            CreateMap<PropertyListingType, PropertyListingTypeCDTO>().ReverseMap();
            CreateMap<PropertyListingType, PropertyListingTypeUDTO>().ReverseMap();


            CreateMap<Country, CountryRDTO>().ReverseMap();


            CreateMap<AppUser, OwnerRDTO>().ReverseMap();


            CreateMap<CategoryCDTO, Category>();
            CreateMap<Category, CategoryRDTO>();
            CreateMap<CategoryUDTO, Category>();
        }
    }

    public static class MapUtils
    {
        public static LocationView MapLocation(Property src)
        {
            return new LocationView
            {
                CityId = src.CityId ?? 0,
                CityName = src.City?.Name,
                RegionId = src.RegionId ?? 0,
                RegionName = src.Region?.Name,
                CountryId = src.CountryId,
                CountryName = src.Country.Name
            };
        }

    }
}
