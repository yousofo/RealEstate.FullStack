using Application.Dtos.Read;
using Application.Interfaces.Repos;
using Domain.Models;
using Infrastructure.Auth.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Auth.Repos
{
    public class AuthRepo(UserManager<AppUser> userManager, IJwtProvider jwtProvider) : IAuthRepo
    {
        public async Task<LoginRDTO?> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            AppUser? user = await userManager.FindByEmailAsync(email);
            if (user is null) return null;

            var isPasswordValid = await userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid) return null;

            var (token, expriesIn) = jwtProvider.GenerateToken(user);

            return new LoginRDTO(user.Id, user.Email, user.FirstName, user.LastName, token, expriesIn);

        }
    }
}
