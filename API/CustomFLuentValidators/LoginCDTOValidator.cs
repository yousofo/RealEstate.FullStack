using Application.Dtos.Create;
using FluentValidation;

namespace API.CustomFLuentValidators
{
    public class LoginCDTOValidator:AbstractValidator<LoginReq>
    {
        public LoginCDTOValidator()
        {
            RuleFor(e=>e.Email).NotEmpty().EmailAddress();
            RuleFor(e => e.Password).NotEmpty().MinimumLength(3);

        }
    }
}
