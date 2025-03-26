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
        public async Task<LoginRes?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
        {
            return await authRepo.GetRefreshTokenAsync(token, refreshToken, cancellationToken);
        }

        public async Task<LoginRes?> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            return await authRepo.LoginAsync(username, password, cancellationToken);
        }

        public async Task<RegisterRes> RegisterAsync(RegisterReq newUser, CancellationToken cancellationToken)
        {
            var errors = await authRepo.RegisterAsync(newUser, cancellationToken);

            if (errors is not null)
            {
                return new RegisterRes(
                    false,
                    errors.Select(e => e.Description)
                );
            }
            else
            {
                return new RegisterRes(true,null);
            }
        }

        public Task<bool> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
