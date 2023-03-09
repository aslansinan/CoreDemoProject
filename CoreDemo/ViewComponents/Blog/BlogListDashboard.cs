using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category;

public class BlogListDashboard : ViewComponent
{
    private BlogManager bm = new BlogManager(new EfBlogRepository());

    public IViewComponentResult Invoke()
    {
        var values = bm.GetBlogListWithCategory();
        return View(values);
    }
}