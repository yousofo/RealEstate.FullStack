using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Errors
{
    public record Error(string Code, string Message)
    {
        public static readonly Error None = new(string.Empty, string.Empty); //dont remember why or what i did here
    }


}
