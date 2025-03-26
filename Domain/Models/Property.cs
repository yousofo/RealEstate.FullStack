using Domain.Enums;
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
    public class Property: AuditableEntity
    {
        [StringLength(150)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        [StringLength(1500)]
        public string Description { get; set; }
        [StringLength(1500)]
        public string PreviewImageLink { get; set; }
        public PropertyStatusEnum Status { get; set; }
        public string? AddressDescription { get; set; }
        public Location Location { get; set; }


        [MaxLength(20)]
        public ICollection<ImageLink>? ImageLinks { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
