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
            CreateMap<Property, PropertyCDTO>().ReverseMap();
            CreateMap<Property, PropertyRDTO>().ReverseMap();
            CreateMap<Property, PropertyRDTO>().ForMember(dto => dto.Category,
                opt => opt.MapFrom(src => src.Category.Title));
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
            //CreateMap<Property, PropertyRDTO>().ForMember(dto =>
            //    dto.Location, opt=>
            //        opt.MapFrom(src=>$"{src.Location.Title}")
            //);
            CreateMap<Property, PropertyUDTO>().ReverseMap();


            CreateMap<Country, CountryRDTO>().ReverseMap();


            CreateMap<Category, CategoryCDTO>().ReverseMap();
            CreateMap<Category, CategoryRDTO>().ReverseMap();
            CreateMap<Category, CategoryUDTO>().ReverseMap();
        }
    }
}
