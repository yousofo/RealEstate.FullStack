using Domain.Auth;
using Domain.Enums;
using Domain.Models.Org;
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
        public string Thumbnail { get; set; }
        public PropertyStatusEnum Status { get; set; }
        public ICollection<PropertyListingType> ListingTypes { get; set; } = [];
        public AppUser Owner { get; set; }
        public string OwnerId { get; set; }
        [MaxLength(20)]
        public Album Album { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }


        //
        public Auction Auction { get; set; }




        //org
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
        public int? OrganizationId { get; set; }


        //location
        [NotMapped]
         public string? AddressDescription { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public int? RegionId { get; set; }
        public Region Region { get; set; }
        
 
    }
}
