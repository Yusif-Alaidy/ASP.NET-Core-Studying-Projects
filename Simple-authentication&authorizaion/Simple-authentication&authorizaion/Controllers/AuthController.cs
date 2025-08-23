using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Simple_authentication_authorizaion.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    // بيانات ثابتة كمثال
    private List<UserModel> users = new List<UserModel>
    {
        new UserModel { Username = "admin", Password = "123", Role = "Admin" },
        new UserModel { Username = "user", Password = "123", Role = "User" }
    };

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel login)
    {
        var user = users.FirstOrDefault(u =>
            u.Username == login.Username && u.Password == login.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role)
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyAtLeast32CharsLong!123"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }

}
