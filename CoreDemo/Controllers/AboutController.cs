using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class AboutController : Controller
{
    AboutManager am = new AboutManager(new EfAboutRepository());

    public IActionResult index()
    {
        return View();
    }

    public PartialViewResult SocialMediaAbout()
    {
        var values = am.GetList();
        return PartialView(values);
    }
}