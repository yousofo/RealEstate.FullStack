using Application.Dtos.RefreshToken;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ServiceExtensions.Validators;

public class RefreshTokenReqValidator : AbstractValidator<RefreshTokenReq>
{
    public RefreshTokenReqValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}


