using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ImageLink
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}
