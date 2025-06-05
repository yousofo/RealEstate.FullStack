using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Dtos.Update;
using AutoMapper;
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
            CreateMap<Property, PropertyRDTO>().ReverseMap();
            CreateMap<Property, PropertyRDTO>().ForMember(dto => dto.Category,
                opt => opt.MapFrom(src => src.Category.Title));
            CreateMap<Property, PropertyRDTO>().ForMember(dto => dto.Owner,
                opt => opt.MapFrom(src => new OwnerRDTO { Id = src.OwnerId, FirstName = src.Owner.FirstName }));
            CreateMap<Property, PropertyRDTO>().ForMember(dto => dto.Location,
                opt => opt.MapFrom(src => new LocationView()
                {
                    CityName = src.City.Name,
                    CityId = src.City.Id,
                    RegionName = src.Region.Name,
                    RegionId = src.Region.Id,
                    CountryName = src.Region.Country.Name,
                    CountryId = src.Region.CountryId,
                }
                ));

            CreateMap<Property, PropertyCDTO>().ReverseMap();
            CreateMap<PropertyCDTO, Property>().ForMember(e => e.ListingTypes, opts => opts.Ignore());
            CreateMap<Property, PropertyCDTO>().ForMember(dto =>
                dto.ListingTypes, opt =>
                    opt.MapFrom(src => $"{src.ListingTypes.Select(e => e.Id)}")
            );

            CreateMap<Property, PropertyUDTO>().ReverseMap();


            CreateMap<PropertyListingType, PropertyListingTypeRDTO>().ReverseMap();
            CreateMap<PropertyListingType, PropertyListingTypeCDTO>().ReverseMap();
            CreateMap<PropertyListingType, PropertyListingTypeUDTO>().ReverseMap();


            CreateMap<Country, CountryRDTO>().ReverseMap();


            CreateMap<Category, CategoryCDTO>().ReverseMap();
            CreateMap<Category, CategoryRDTO>().ReverseMap();
            CreateMap<Category, CategoryUDTO>().ReverseMap();
        }
    }
}
