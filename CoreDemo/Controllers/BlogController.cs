using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

[AllowAnonymous]
public class BlogController : Controller
{
    private BlogManager bm = new BlogManager(new EfBlogRepository());

    public IActionResult index()
    {
        var values = bm.GetBlogListWithCategory();
        return View(values);
    }

    public IActionResult BlogReadAll(int id)
    {
        ViewBag.i = id;
        var values = bm.GetBlogById(id);
        return View(values);
    }

    public IActionResult BlogListByWriter()
    {
        var values = bm.GetBlogListWithWriter(1);
        return View(values);
    }
}