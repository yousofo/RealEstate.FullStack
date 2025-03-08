using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Read
{
    public record LoginRDTO(
        string Id,
        string? Email,
        string FirstName,
        string LastName,
        string Token,
        int ExpiresIn
    );
}
