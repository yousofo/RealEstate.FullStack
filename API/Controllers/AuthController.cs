using Application.Dtos.Auth;
//using Application.Dtos.Read;
using Application.Dtos.RefreshToken;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Auth;
using Application.Services;
using Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IServicesManager manager, UserManager<AppUser> userManager) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginReq request, CancellationToken cancellationToken)
        {
            var result = await manager.Auth.LoginAsync(request.Email, request.Password, cancellationToken);
            return result is null ? BadRequest("invalid email or password") : Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenReq request, CancellationToken cancellationToken)
        {
            var result = await manager.Auth.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            return result is null ? BadRequest("invalid email or password") : Ok(result);
        }

        [HttpPut("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshTokenAsync([FromBody] RefreshTokenReq request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterReq request, CancellationToken cancellationToken)
        {
            var result = await manager.Auth.RegisterAsync(request, cancellationToken);
            return result is null ? BadRequest("failed") : Ok(result);
        }
    }
}
