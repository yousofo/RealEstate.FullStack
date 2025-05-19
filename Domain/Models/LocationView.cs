using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Keyless]
     public class LocationView
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }

     }
}
