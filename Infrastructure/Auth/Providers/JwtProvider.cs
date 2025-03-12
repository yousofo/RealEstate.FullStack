using Infrastructure.Auth.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Auth.Providers
{
    public class JwtProvider : IJwtProvider
    {
        public (string token, int expiresIn) GenerateToken(AppUser user)
        {
            Claim[] claims = [
                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email!),
                new(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new(JwtRegisteredClaimNames.FamilyName,user.LastName),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            ];
            
            //encryption 
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("uvnGJQgmd4uOyyzQpDVk8fQ7KwCFiFFI"));

            var singingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var expiresIn = 30;

            //whats going to be inside the generated token
            var token = new JwtSecurityToken(
                    issuer: "RealEstateApp",
                    audience: "RealEstateApp users",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(expiresIn),
                    signingCredentials: singingCredentials
                );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiresIn * 60);
        }
    }
}
