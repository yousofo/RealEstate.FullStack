using Domain.Auth;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Album:BaseEntity
    {
        public AppUser User { get; set; }
        public string? UserId { get; set; }
        public Property Property { get; set; }
        public int? PropertyId { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
