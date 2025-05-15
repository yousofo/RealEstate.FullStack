using Application.Dtos.Read;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IAuthRepo
    {
        Task<LoginRes?> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<LoginRes?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
        Task<bool?> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);

        public Task<IEnumerable<IdentityError>?> RegisterAsync(RegisterReq newUser, CancellationToken cancellationToken);

    }
}
