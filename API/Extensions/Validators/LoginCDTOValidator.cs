using Application.Dtos.Auth;
using FluentValidation;

namespace API.Extensions.Validators
{
    public class LoginReqValidator : AbstractValidator<LoginReq>
    {
        public LoginReqValidator()
        {
            RuleFor(e => e.Email).NotEmpty().EmailAddress();
            RuleFor(e => e.Password).NotEmpty().MinimumLength(3);

        }
    }
}
