using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class LoginController : Controller
{
    [AllowAnonymous]
    public IActionResult index()
    {
        return View();
    }
    [HttpPost]
    [AllowAnonymous]
    public IActionResult index(Writer p)
    {
        Context c = new Context();
        var datavalue = c.Writers.FirstOrDefault(x=>x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
        if (datavalue != null)
        {
            HttpContext.Session.SetString("username",p.WriterMail);
            return RedirectToAction("index", "Writer");
        }
        else
        {
            return View();
        }
        return View();
    }
}