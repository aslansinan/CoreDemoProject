using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;
[Authorize]
public class WriterController : Controller
{
    private WriterManager _writerManager = new WriterManager(new EfWriterRepository());
    public IActionResult index()
    {
        return View();
    }
    public IActionResult WriterProfile()
    {
        return View();
    }
    public IActionResult WriterMail()
    {
        return View();
    }
    [AllowAnonymous]
    public IActionResult Test()
    {
        return View();
    }
    [AllowAnonymous]
    public PartialViewResult WriterNavbarPartial()
    {
        return PartialView();
    }
    [AllowAnonymous]
    public PartialViewResult WriterFooterPartial()
    {
        return PartialView();
    }

    [AllowAnonymous]
    public IActionResult WriterEditProfile()
    {
        var writervalues = _writerManager.TGetById(1);
        return View(writervalues);
    }
}