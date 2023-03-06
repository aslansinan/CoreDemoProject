using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class LoginController : Controller
{
    [AllowAnonymous]
    public IActionResult index()
    {
        return View();
    }
}