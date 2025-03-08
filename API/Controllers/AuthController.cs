using Application.Dtos.Create;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginCDTO loginCDT, CancellationToken cancellationToken)
        {
            var result = await authService.LoginAsync(loginCDT.Email, loginCDT.Password, cancellationToken);
            return result is null ? BadRequest("invalid email or password") : Ok(result);
        }
    }
}
