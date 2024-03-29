﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;
[AllowAnonymous]
public class NewsLetterController : Controller
{
    NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
    [HttpGet]
    public PartialViewResult SubscribeMail()
    {
        return PartialView();
    }
    
    [HttpPost]
    public IActionResult SubscribeMail(NewsLetter p)
    {
        p.MailStatus = true;
        nm.TAdd(p);
        Response.Redirect("/Blog/BlogReadAll/" + 1);
        return PartialView();
    }
}   