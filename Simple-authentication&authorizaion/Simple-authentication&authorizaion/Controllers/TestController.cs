using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdmin()
    {
        return Ok("You are admin");
    }

    [HttpGet("user")]
    [Authorize(Roles = "User")]
    public IActionResult GetUser()
    {
        return Ok("You are user");
    }

    [HttpGet("any")]
    [Authorize]
    public IActionResult GetAny()
    {
        return Ok($"Hello {User.Identity.Name}");
    }

    [HttpGet("public")]
    public IActionResult PublicEndpoint()
    {
        return Ok("You need to login");
    }
}
