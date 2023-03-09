using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;
[AllowAnonymous]
public class DashboardController : Controller
{
    public IActionResult index()
    {
        return View();
    }
}