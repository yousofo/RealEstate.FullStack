using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Auth
{
    public record RegisterReq(
        [EmailAddress] string Email,
        [StringLength(100,MinimumLength =3)]string UserName,
        [StringLength(20)]string FirstName,
        [StringLength(20)]string LastName,
        [StringLength(100, MinimumLength = 6)] string Password,
        [StringLength(50)] string PhoneNumber    
    );
}
