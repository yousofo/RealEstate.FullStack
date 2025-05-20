using Application.Dtos.Auth;
using Application.Exceptions;
using Application.Interfaces.Repos;
using Domain.Enums;
using Domain.Models;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Infrastructure.Repos
{
    public class AuthRepo(UserManager<AppUser> userManager, JwtProvider jwtProvider) : IAuthRepo
    {
        private readonly int _refreshTokenExpiryDays = 14;
        public async Task<LoginRes> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            AppUser? user = await userManager.FindByEmailAsync(email);
            if (user is null) throw new BadRequestException("email or pass incorrect");
            //AQAAAAIAAYagAAAAEKnxVxlk/0Smj677S6OBqx+zWe4QJLQvC2fj2A6+mnhDXYBTRiWuPApdBjJdjcSrvA== //reg
            var passwordhash = userManager.PasswordHasher.HashPassword(user, password);

            var isPasswordValid = await userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid) throw new BadRequestException("email or pass incorrect");

            var (token, expiresIn) = jwtProvider.GenerateToken(user);

            var refreshToken = GenerateRefreshToken();
            var refreshTokenExpirationDate = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                ExpiresOn = refreshTokenExpirationDate
            });

            await userManager.UpdateAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            return new LoginRes(user.Id,
                Email: user.Email!,
                user.FirstName,
                user.LastName,
                Token: token,
                ExpiresIn: expiresIn,
                Refreshtoken: refreshToken,
                Roles: roles,
                RefreshTokenExpirationDate: refreshTokenExpirationDate
            );

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

            var roles = await userManager.GetRolesAsync(user);

            return new LoginRes(user.Id,
                Email: user.Email!,
                FirstName: user.FirstName,
                LastName: user.LastName,
                Token: newToken,
                ExpiresIn: expriesIn,
                Refreshtoken: newRefreshToken,
                Roles: roles,
                refreshTokenExpirationDate
            );

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
                PhoneNumber = newUser.PhoneNumber,
            };
            var passwordhash = userManager.PasswordHasher.HashPassword(user, newUser.Password);

            var result = await userManager.CreateAsync(
                user,
                //userManager.PasswordHasher.HashPassword(user, newUser.Password)//what was i drinking
                newUser.Password
            );


            if (result.Succeeded)
            {
                var role = RolesEnum.Customer.ToString();
                await userManager.AddToRoleAsync(user, RolesEnum.Customer.ToString());

                //await userManager.UpdateAsync(user);

                return null;
            }
            else
            {
                throw new Exception(result.Errors.Select(e=>e.Description).First());
            }
        }


        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
