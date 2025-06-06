﻿using Domain.Attributes;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Country: AuditableEntity
    {
        [Searchable]
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Region> Regions { get; set; }
     }
}
