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
            CreateMap<Property, PropertyRDTO>()
                .ForMember(dto => dto.ListingTypes,
                   opt => opt.MapFrom(src => src.ListingTypes.Select(e => new PropertyListingTypeRDTO { Id = e.Id, Title = e.Title }))
                )
                .ForMember(dto => dto.Location,
                   opt => opt.MapFrom(src => new LocationView()
                   {
                       CountryId = src.CountryId,
                       CountryName = src.Country != null ? src.Country.Name : null,
                       RegionId = src.RegionId,
                       RegionName = src.Region != null ? src.Region.Name : null,
                       CityId = src.CityId,
                       CityName = src.City != null ? src.City.Name : null
                   }));



            CreateMap<Album, AlbumRDTO>();
            CreateMap<Video, VideoRDTO>();
            CreateMap<Image, ImageRDTO>();


            CreateMap<PropertyCDTO, Property>().ForMember(e => e.ListingTypes, opts => opts.Ignore());

            // Create a mapping for LocationView





            CreateMap<PropertyListingType, PropertyListingTypeRDTO>();
            CreateMap<PropertyListingTypeCDTO, PropertyListingType>();
            CreateMap<PropertyListingTypeUDTO, PropertyListingType>();


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
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("mapper config");
            Console.WriteLine(src.Country.Name);
            Console.WriteLine("\n\n\n\n\n");

            return new LocationView()
            {
                CountryId = src.CountryId,
                CountryName = src.Country.Name,
                RegionId = src.RegionId ?? 0,
                RegionName = src.Region?.Name,
                CityId = src.CityId ?? 0,
                CityName = src.City?.Name
            };
        }

    }
}
