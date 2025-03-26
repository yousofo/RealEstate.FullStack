using Application.Dtos.Read;
using Application.Interfaces.Repos.Auth;
using Application.Interfaces.Services.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Auth
{
    public class AuthService(IAuthRepo authRepo) : IAuthService
    {
        readonly Dictionary<string, string> identityErrorMapping = new()
        {
            { "DefaultError", "general" },
            { "ConcurrencyFailure", "general" },
            { "PasswordTooShort", "password" },
            { "PasswordRequiresNonAlphanumeric", "password" },
            { "PasswordRequiresDigit", "password" },
            { "PasswordRequiresLower", "password" },
            { "PasswordRequiresUpper", "password" },
            { "PasswordMismatch", "password" },
            { "DuplicateUserName", "email" },
            { "DuplicateEmail", "email" },
            { "InvalidEmail", "email" },
            { "InvalidUserName", "username" },
            { "InvalidRoleName", "role" },
            { "DuplicateRoleName", "role" },
            { "UserAlreadyHasPassword", "password" },
            { "UserLockoutNotEnabled", "general" },
            { "UserAlreadyInRole", "role" },
            { "UserNotInRole", "role" },
            { "LoginAlreadyAssociated", "email" },
            { "InvalidToken", "general" },
            { "RecoveryCodeRedemptionFailed", "recovery_code"}
        };



        public async Task<LoginRes?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
        {
            return await authRepo.GetRefreshTokenAsync(token, refreshToken, cancellationToken);
        }

        public async Task<LoginRes?> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            return await authRepo.LoginAsync(email, password, cancellationToken);
        }

        public async Task<RegisterRes> RegisterAsync(RegisterReq newUser, CancellationToken cancellationToken)
        {
            var errors = await authRepo.RegisterAsync(newUser, cancellationToken);

            if (errors is not null)
            {
                return new RegisterRes(
                    false,
                    errors.Select(e => new AuthError(
                        //e.Code, 
                        GetErrorField(e.Code), 
                        e.Description
                    ))
                );
            }
            else
            {
                return new RegisterRes(true, null);
            }
        }

        public Task<bool> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }





        private string GetErrorField(string code)
        {
            var field = identityErrorMapping.GetValueOrDefault(code);
            return field ?? "general";
            //return code switch
            //{
            //    "DuplicateUserName" => "email",
            //    "InvalidEmail" => "email",
            //    "PasswordTooShort" => "password",
            //    _ => "general"
            //};
        }

    }
}
