using jwt.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DefaultController : ControllerBase
{
    [HttpGet("[action]")]
    public IActionResult Login()
    {
        return Created("", new BuildToken().CreateToken());
    }

    [Authorize]
    [HttpGet("[action]")]
    public IActionResult Page1()
    {
        return Ok("sayfa 1 için giriş başarılı");
    }
}