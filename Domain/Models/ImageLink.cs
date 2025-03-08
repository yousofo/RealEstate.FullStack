using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ImageLink :EntityBase
    {
        [StringLength(500)]
        public string Link { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}
