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
        public PropertyListingType ListingType { get; set; }
        


        public IFormFile Thumbnail { get; set; }
        public IEnumerable<IFormFile>? Images { get; set; }
        public int? OrganizationId { get; set; }
        public int CategoryId { get; set; }




        //location
        public int Country { get; set; }
        public int? City { get; set; }
        public int? Region { get; set; }
        public int? District { get; set; }
        public string? State { get; set; }
        public string? AddressDescription { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
    }
}
