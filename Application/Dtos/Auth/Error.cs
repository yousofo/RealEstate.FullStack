using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Dtos.Auth
{
    public record AuthError(
        string Code,
        string Field,
        string Description
    );
}
