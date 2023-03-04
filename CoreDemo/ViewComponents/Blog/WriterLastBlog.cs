using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category;

public class WriterLastBlog : ViewComponent
{
    private BlogManager bm = new BlogManager(new EfBlogRepository());

    public IViewComponentResult Invoke()
    {
        var values = bm.GetBlogListWithWriter(1);
        return View(values);
    }
}