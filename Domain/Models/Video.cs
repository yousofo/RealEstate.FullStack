using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Video: AuditableEntity
    {
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Link { get; set; } = "";
        public string format { get; set; } = "";
        public string thumbnail { get; set; }

    }
}
