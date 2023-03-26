using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class MessageController : Controller
{
    public IActionResult Inbox()
    {
        return View();
    }
}