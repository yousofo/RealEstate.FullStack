using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Create
{
    public record LoginCDTO(
            [Required] string Email,
            [Required] string Password
        );
}
