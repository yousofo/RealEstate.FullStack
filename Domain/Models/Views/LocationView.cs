using Domain.Attributes;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Views
{
    [Keyless]
    public class LocationView
    {
        public int CountryId { get; set; }
        [Searchable]
        public string CountryName { get; set; }

        public int RegionId { get; set; }
        [Searchable]
        public string RegionName { get; set; }

        public int CityId { get; set; }
        [Searchable]
        public string CityName { get; set; }

    }
}
