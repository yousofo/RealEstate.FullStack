using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Auth
{
    public record RegisterRes(
        bool Success,
        IEnumerable<AuthError>? Errors
        //string? Id,
        //string? Email,
        //string? FirstName,
        //string? LastName,
        //string? Token,
        //int? ExpiresIn,
        //string? Refreshtoken,
        //DateTime? refreshTokenExpirationDate
    );
}
