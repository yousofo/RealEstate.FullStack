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
        public async Task<LoginRDTO?> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            return await authRepo.LoginAsync(username, password, cancellationToken);
        }
    }
}
