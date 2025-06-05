using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PropertyListingType:AuditableEntity
    {
        [StringLength(100)]
        public string Title { get; set; }
        public ICollection<Property> Properties { get; set; } = [];
    }
}
