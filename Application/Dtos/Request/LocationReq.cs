using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Request
{
    public class LocationReq
    {
 
        public string CountryName { get; set; }

 
        public string? RegionName { get; set; }
 
        public string? CityName { get; set; }
    }
}
