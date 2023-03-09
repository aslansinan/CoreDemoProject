using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;
[AllowAnonymous]
public class DashboardController : Controller
{
    public IActionResult index()
    {
        Context c = new Context();
        ViewBag.v1 = c.Blogs.Count().ToString();
        ViewBag.v2 = c.Blogs.Where(x=>x.WriterID==1).Count().ToString();
        ViewBag.v3 = c.Categories.Count().ToString();
        return View();
    }
}