using Application.Dtos.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IAuthRepo
    {
        Task<LoginReq?> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<LoginReq?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
        Task<bool?> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);


    }
}
