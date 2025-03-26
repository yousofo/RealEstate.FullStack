using Application.Dtos.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginRes?> LoginAsync(string username, string password, CancellationToken cancellationToken = default);
        Task<LoginRes?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
        Task<bool> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);

        public Task<RegisterRes> RegisterAsync(RegisterReq newUser,CancellationToken cancellationToken);
    }
}
