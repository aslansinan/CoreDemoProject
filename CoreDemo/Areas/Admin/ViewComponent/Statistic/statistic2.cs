using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponent.Statistic;

public class statistic2 : Microsoft.AspNetCore.Mvc.ViewComponent
{
    Context _context = new Context();
    public IViewComponentResult Invoke()
    {
        ViewBag.v1 = _context.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault() ?? string.Empty;
        ViewBag.v2 = _context.Comments.Count();
        return View();
    }
}