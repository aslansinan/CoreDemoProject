using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;
[Authorize]
public class WriterController : Controller
{
    private WriterManager _writerManager = new WriterManager(new EfWriterRepository());
    UserManager userManager = new UserManager(new EfUserRepository());

    private readonly UserManager<AppUser> _userManager;

    public WriterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

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
    public async Task<IActionResult> WriterEditProfile()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        UserUpdateViewModel model = new UserUpdateViewModel();
        model.Mail = values.Email;
        model.NameSurname = values.NameSurname;
        model.İmageUrl = values.ImageUrl;
        model.UserName = values.UserName;
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdateViewModel)
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        values.NameSurname = userUpdateViewModel.NameSurname;
        values.Email = userUpdateViewModel.Mail;
        values.UserName = userUpdateViewModel.UserName;
        values.ImageUrl = userUpdateViewModel.İmageUrl;
        values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userUpdateViewModel.Password);
        var result = await _userManager.UpdateAsync(values);
        return RedirectToAction("index", "Dashboard");
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