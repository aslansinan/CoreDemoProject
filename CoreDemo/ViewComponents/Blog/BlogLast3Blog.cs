using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category;

public class BlogLast3Blog : ViewComponent
{
    private BlogManager bm = new BlogManager(new EfBlogRepository());

    public IViewComponentResult Invoke()
    {
        var values = bm.GetLast3Blog();
        return View(values);
    }
}