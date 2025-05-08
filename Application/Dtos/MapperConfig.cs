using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Dtos.Update;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<Property, PropertyCDTO>().ReverseMap();
            CreateMap<Property, PropertyRDTO>().ReverseMap();
            CreateMap<Property, PropertyRDTO>().ForMember(dto => dto.Category,
                opt => opt.MapFrom(src => src.Category.Title));
            //CreateMap<Property, PropertyRDTO>().ForMember(dto =>
            //    dto.Location, opt=>
            //        opt.MapFrom(src=>$"{src.Location.Title}")
            //);
            //CreateMap<Property, PropertyRDTO>().ForMember(dto => dto.Categories, 
            //    opt => opt.MapFrom(src => src.Categories.Select(c => c.Title)));
            CreateMap<Property, PropertyUDTO>().ReverseMap();

            CreateMap<Location, LocationCDTO>().ReverseMap();
            CreateMap<Location, LocationRDTO>().ReverseMap();
            CreateMap<Location, LocationUDTO>().ReverseMap();

            CreateMap<Category, CategoryCDTO>().ReverseMap();
            CreateMap<Category, CategoryRDTO>().ReverseMap();
            CreateMap<Category, CategoryUDTO>().ReverseMap();
        }
    }
}
