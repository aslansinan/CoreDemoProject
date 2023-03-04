using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class LoginController : Controller
{
    public IActionResult index()
    {
        return View();
    }
}