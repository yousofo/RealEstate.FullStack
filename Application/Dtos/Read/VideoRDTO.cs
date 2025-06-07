using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Read
{
    public class VideoRDTO
    {
         public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Link { get; set; } = "";
        public string format { get; set; } = "";
        public string thumbnail { get; set; }
    }
}
