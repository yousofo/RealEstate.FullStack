using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Read
{
    public class PropertyRDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PreviewImageLink { get; set; }
        public string Status { get; set; }
        public Location Location { get; set; }
        public IEnumerable<string>? ImageLinks { get; set; }
        public IEnumerable<string>? Categories { get; set; }

    }
}
