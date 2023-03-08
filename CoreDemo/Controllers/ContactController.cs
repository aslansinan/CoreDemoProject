using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class ContactController : Controller
{
    private ContactManager cm = new ContactManager(new EfContactRepository());

    [HttpGet]
    public IActionResult index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult index(Contact p)
    {
        p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        p.ContactStatus = true;
        cm.TAdd(p);
        return RedirectToAction("index", "Blog");
        return View();
    }
}