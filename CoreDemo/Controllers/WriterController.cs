using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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

    [HttpGet]
    public IActionResult WriterEditProfile()
    {
        Context context = new Context(); 
        var userMail = User.Identity?.Name;
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
            .FirstOrDefault();
        var writervalues = _writerManager.TGetById(writerId);
        return View(writervalues);
    }
    [HttpPost]
    public IActionResult WriterEditProfile(Writer writer)
    {
        WriterValidator writerValidator = new WriterValidator();
        ValidationResult results = writerValidator.Validate(writer);
        if (results.IsValid)
        {
            _writerManager.TUpdate(writer);
            return RedirectToAction("index", "Dashboard");
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
            }
        }
        return View();
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult WriterAdd()
    {
        return View();
    }
    [AllowAnonymous]
    [HttpPost]
    public IActionResult WriterAdd(AddProfileImage writer)
    {
        Writer w = new Writer();
        if (writer.WriterImage != null)
        {
            var extension = Path.GetExtension(writer.WriterImage.FileName);
            var newimagename = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writer/WriterImageFiles/", newimagename);
            var stream = new FileStream(location, FileMode.Create);
            writer.WriterImage.CopyTo(stream);
            w.WriterImage = newimagename;
        }

        w.WriterName = writer.WriterName;
        w.WriterMail = writer.WriterMail;
        w.WriterPassword = writer.WriterPassword;
        w.WriterStatus = true;
        w.WriterAbout = writer.WriterAbout;
        _writerManager.TAdd(w);
       return RedirectToAction("index", "Dashboard");
    }
}