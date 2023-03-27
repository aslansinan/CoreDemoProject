using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminBlogController : Controller
{
    private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
    public IActionResult Index()
    {
        var values = _blogManager.GetBlogListWithCategory();
        return View(values);
    }
}