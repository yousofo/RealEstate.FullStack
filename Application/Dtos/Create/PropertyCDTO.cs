using Application.Dtos.Read;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Create
{
    public class PropertyCDTO
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        //public PropertyStatusEnum Status { get; set; } = PropertyStatusEnum.Pending;
        public int[] ListingTypes { get; set; }



        public IFormFile Thumbnail { get; set; }
        public IEnumerable<IFormFile>? Images { get; set; }
        public int? OrganizationId { get; set; }
        public int CategoryId { get; set; }




        //location
        public string CountryName { get; set; }
        public string? CityName { get; set; }
        public string? RegionName { get; set; }
        public string? AddressDescription { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
    }
}
