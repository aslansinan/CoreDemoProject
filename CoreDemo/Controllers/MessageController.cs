using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

[AllowAnonymous]
public class MessageController : Controller
{
    private Message2Manager _message2Manager = new Message2Manager(new EfMessage2Repository());
    private Context context = new Context();
    public IActionResult InBox()
    {
        var username = User.Identity?.Name;
        var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
        var values = _message2Manager.GetInboxListByWriter(writerId);
        //var values = _message2Manager.GetList();
        return View(values);
    }

    public IActionResult MessageDetails(int id)
    {
        var value = _message2Manager.TGetById(id);
        return View(value);
    }
}