using Auth_tutorial.Entities;
using Auth_tutorial.Models;
using Auth_tutorial.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth_tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {

            var user = await authService.RegisterAsync(request);
            if (user == null) 
            {
                return BadRequest("Username already exists.");
            }
            return Ok(user);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var token = await authService.LoginAsync(request);
            if (token is null) 
            {
                return BadRequest("Invalid user name or password");
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint() {
            return Ok("You Are Authenticated. ");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AdminOnly")]
        public IActionResult AdminOnlyEndpoint() {
            return Ok("You Are Admin. ");
        }


        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokenAsync(request);

            if (result is null || result.AccessToken is null || result.RefreshToken is null) return Unauthorized("Invalid refresh token. ");

            return Ok(result);
        }
    }
}
