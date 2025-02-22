using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Property
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [StringLength(1200)]
        public string Description { get; set; }
        public string PreviewImageLink { get; set; }
        public ICollection<ImageLink>? ImageLinks { get; set; }
        public int? LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
