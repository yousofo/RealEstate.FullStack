using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Update
{
    public class PropertyUDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PreviewImageLink { get; set; }
        public IEnumerable<string>? ImageLinks { get; set; }
        public IFormFile PreviewImage { get; set; }
        public IEnumerable<IFormFile>? Images { get; set; }
    }
}
