using Application.Dtos.Auth;
//using Application.Dtos.Read;
using Application.Dtos.RefreshToken;
using Application.Interfaces.Services;
 using Application.Services;
using Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IServicesManager manager, UserManager<AppUser> userManager) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginReq request, CancellationToken cancellationToken)
        {
            var result = await manager.Auth.LoginAsync(request.Email, request.Password, cancellationToken);

            if(result is  null)
            {
                return BadRequest("invalid email or password");
            }

            //was for XXS attacks
            //Response.Cookies.Append("Jwt", result.Token, new CookieOptions
            //{
            //    HttpOnly = true,
            //    //Secure = true,               // true if HTTPS
            //    SameSite = SameSiteMode.Lax, // for cross-origin
            //    Expires = DateTimeOffset.UtcNow.AddDays(7),
            //    //Domain = "localhost", // for cross-origin,
            //    //Path = "/",                   // this is fine
            //    //Expires = DateTimeOffset.UtcNow + TimeSpan.FromHours(3)
            //});
            //Console.WriteLine(result.Token);
            return Ok(result);

        }



        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] RegisterReq registerReq,CancellationToken cancellationToken)
        {
            var registerRes = await manager.Auth.RegisterAsync(registerReq, cancellationToken);

            return registerRes.Success ? Ok(registerRes) : BadRequest(registerRes);
        }



        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh ([FromBody] RefreshTokenReq request, CancellationToken cancellationToken)
        {
            var result = await manager.Auth.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            return result is null ? BadRequest("invalid email or password") : Ok(result);
        }






        [HttpPut("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshToken ([FromBody] RefreshTokenReq request, CancellationToken cancellationToken)
        {
            var isRevoked = await manager.Auth.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            return isRevoked ? Ok(isRevoked) : BadRequest("failed");
        }





        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userManager.Users.ToListAsync();
            return Ok(users);
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterReq request, CancellationToken cancellationToken)
        {
            var result = await manager.Auth.RegisterAsync(request, cancellationToken);
            return result is null ? BadRequest("failed") : Ok(result);
        }
    }
}
