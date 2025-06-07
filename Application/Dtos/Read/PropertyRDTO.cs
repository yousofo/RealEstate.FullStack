using Domain.Models;
using Domain.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Read
{
    public class PropertyRDTO
    {
        public PropertyRDTO()
        {
            
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Status { get; set; }
         public string? AddressDescription { get; set; }
        public AlbumRDTO Album { get; set; }
        public CategoryRDTO Category { get; set; }
        public LocationView Location { get; set; } = new();
        public OwnerRDTO Owner { get; set; }
        public IEnumerable<PropertyListingTypeRDTO> ListingTypes { get; set; } = [];

    }
}
