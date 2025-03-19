using Application.Dtos.Read;
using Application.Interfaces;
using Application.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
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

        public Task<bool> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
