using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponent.Statistic;

public class statistic1 : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
    Context _context = new Context();
    public IViewComponentResult Invoke()
    {
        ViewBag.v1 = _blogManager.GetList().Count;
        ViewBag.v2 = _context.Contacts.Count();
        ViewBag.v3 = _context.Comments.Count();
        return View();
    }
}