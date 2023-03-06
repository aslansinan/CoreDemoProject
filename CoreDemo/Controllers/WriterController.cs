﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;
[Authorize]
public class WriterController : Controller
{
    [AllowAnonymous]
    public IActionResult index()
    {
        return View();
    }
    public IActionResult WriterProfile()
    {
        return View();
    }
    public IActionResult WriterMail()
    {
        return View();
    }
}