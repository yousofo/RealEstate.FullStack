using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public class JwtProvider(IConfiguration configuration)
    {
        public string? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = symmetricSecurityKey,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                return jwtToken.Claims.First(e => e.Type == JwtRegisteredClaimNames.Sub).Value;//user id
            }
            catch
            {
                return null;
            }
        }

        public (string token, int expiresIn) GenerateToken(AppUser user, IList<string> roles)
        {
            List<Claim> claims = [
                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email!),
                new(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new(JwtRegisteredClaimNames.FamilyName,user.LastName),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            ];
            
            foreach(var role  in roles)
            {
               claims.Add(new(ClaimTypes.Role, role));
            }

            //encryption 
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            var singingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var expiryMinutes = int.Parse(configuration["Jwt:ExpiryMinutes"]!);

            //whats going to be inside the generated token
            var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(expiryMinutes),
                    signingCredentials: singingCredentials
                );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiryMinutes * 60);
        }
    }
}
