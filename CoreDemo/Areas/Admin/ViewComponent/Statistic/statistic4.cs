using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponent.Statistic;

public class statistic4 : Microsoft.AspNetCore.Mvc.ViewComponent
{
    Context _context = new Context();
    public IViewComponentResult Invoke()
    {
        ViewBag.v1 = _context.Admins.Where(x => x.AdminId == 1).Select(y => y.Name).FirstOrDefault();
        ViewBag.v2 = _context.Admins.Where(x => x.AdminId == 1).Select(y => y.ImageUrl).FirstOrDefault();
        ViewBag.v3 = _context.Admins.Where(x => x.AdminId == 1).Select(y => y.ShortDescription).FirstOrDefault();
        return View();
    }
}