using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Property: AuditableEntity
    {
        [StringLength(150)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        [StringLength(1500)]
        public string Description { get; set; }
        [StringLength(1500)]
        public string PreviewImageLink { get; set; }
        [MaxLength(20)]
        public ICollection<ImageLink>? ImageLinks { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
