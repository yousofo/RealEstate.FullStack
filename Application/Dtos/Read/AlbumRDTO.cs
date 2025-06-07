using Domain.Auth;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Read
{
    public class AlbumRDTO
    {
        public int Id { get; set; }
        public IEnumerable<VideoRDTO> Videos { get; set; } = [];
        public IEnumerable<ImageRDTO> Images { get; set; } = [];
    }
}
