using Application.Dtos.Auth;
using Application.Interfaces.Repos.Auth;
using Domain.Models;
using Infrastructure.Auth.Interfaces;
using Infrastructure.Auth.Providers;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Infrastructure.Auth.Repos
{
    public class AuthRepo(UserManager<AppUser> userManager, JwtProvider jwtProvider) : IAuthRepo
    {
        private readonly int _refreshTokenExpiryDays = 14;
        public async Task<LoginRes?> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            AppUser? user = await userManager.FindByEmailAsync(email);
            if (user is null) return null;

            var isPasswordValid = await userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid) return null;

            var (token, expriesIn) = jwtProvider.GenerateToken(user);

            var refreshToken = GenerateRefreshToken();
            var refreshTokenExpirationDate = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                ExpiresOn = refreshTokenExpirationDate
            });
            
            await userManager.UpdateAsync(user);

            return new LoginRes(user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                token,
                expriesIn,
                refreshToken,
                refreshTokenExpirationDate);

        }
        

        public async Task<LoginRes?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
        {
            var userId = jwtProvider.ValidateToken(token);
            if (userId is null) return null;

            var user = await userManager.FindByIdAsync(userId);
            
            if (user is null) return null;

            var userRefreshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsValid);
            if (userRefreshToken is null) return null;

            userRefreshToken.RevokenOn = DateTime.UtcNow;

            var (newToken, expriesIn) = jwtProvider.GenerateToken(user);

            var newRefreshToken = GenerateRefreshToken();
            var refreshTokenExpirationDate = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = newRefreshToken,
                ExpiresOn = refreshTokenExpirationDate
            });

            await userManager.UpdateAsync(user);

            return new LoginRes(user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                newToken,
                expriesIn,
                newRefreshToken,
                refreshTokenExpirationDate);

        }

        

        public async Task<bool?> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
        {
            var userId = jwtProvider.ValidateToken(token);
            if (userId is null) return false;

            var user = await userManager.FindByIdAsync(userId);
            if (user is null) return false;

            var userRefreshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsValid);

            if (userRefreshToken is null) return false;

            userRefreshToken.RevokenOn = DateTime.UtcNow;

            await userManager.UpdateAsync(user);

            return true;
        }


        public async Task<IEnumerable<IdentityError>?> RegisterAsync(RegisterReq newUser, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                Email = newUser.Email,
                UserName = newUser.Email,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                PhoneNumber=newUser.PhoneNumber,                
            };
            var result = await userManager.CreateAsync(
                user, 
                userManager.PasswordHasher.HashPassword(user, newUser.Password)
            );

            if (result.Succeeded)
            {
                //await userManager.UpdateAsync(user);

                return null;
            }
            else
            {
                return result.Errors;
            }
        } 


        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
