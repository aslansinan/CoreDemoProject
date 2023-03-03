using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

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
        var values = bm.GetBlogById(id);
        return View(values);
    }
}