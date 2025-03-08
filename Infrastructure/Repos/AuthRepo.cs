using Application.Dtos.Read;
using Application.Interfaces.Repos;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repos
{
    public class AuthRepo(UserManager<AppUser> userManager) : IAuthRepo
    {
        public async Task<LoginRDTO?> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            AppUser? user = await userManager.FindByEmailAsync(email);
            if (user == null) return null;
            var isPasswordValid = await userManager.CheckPasswordAsync(user, password);

            if (!isPasswordValid) return null;

            

            return new LoginRDTO(user.Id, user.Email, user.FirstName, user.LastName, "ttt", 3600);

        }
    }
}
