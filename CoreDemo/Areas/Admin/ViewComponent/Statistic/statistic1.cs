using System.Xml.Linq;
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
        string api = "af954833f1a0cfe37c9cef6f40c5844e";
        string connection =
            "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&appid=" + api;
        XDocument document = XDocument.Load(connection);
        ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value")?.Value;
        return View();
    }
}