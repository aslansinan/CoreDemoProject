﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;
public class DashboardController : Controller
{
    public IActionResult index()
    {
        Context c = new Context();
        var username = User.Identity?.Name;
        var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
        var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
        ViewBag.v1 = c.Blogs.Count().ToString();
        ViewBag.v2 = c.Blogs.Where(x=>x.WriterId==writerId).Count().ToString();
        ViewBag.v3 = c.Categories.Count().ToString();
        return View();
    }
}