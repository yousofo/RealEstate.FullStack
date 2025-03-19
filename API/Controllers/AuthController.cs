using Application.Dtos.Create;
using Application.Dtos.RefreshToken;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginReq request, CancellationToken cancellationToken)
        {
            var result = await authService.LoginAsync(request.Email, request.Password, cancellationToken);
            return result is null ? BadRequest("invalid email or password") : Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenReq request, CancellationToken cancellationToken)
        {
            var result = await authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            return result is null ? BadRequest("invalid email or password") : Ok(result);
        }

        [HttpPut("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshTokenAsync([FromBody] RefreshTokenReq request, CancellationToken cancellationToken)
        {
            var isRevoked = await authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            return isRevoked ? Ok(isRevoked) : BadRequest("failed");
        }
    }
}
