using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Region:AuditableEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
        public ICollection<City> Cities { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
