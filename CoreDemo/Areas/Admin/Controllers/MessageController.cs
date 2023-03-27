using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class MessageController : Controller
{
    private Message2Manager _message2Manager = new Message2Manager(new EfMessage2Repository());
    private Context context = new Context();

    public IActionResult Inbox()
    {
        var username = User.Identity?.Name;
        var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
        var values = _message2Manager.GetInboxListByWriter(writerId);
        return View(values);
    }

    [HttpGet]
    public IActionResult SendBox()
    {
        var username = User.Identity?.Name;
        var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
        var values = _message2Manager.GetSendBoxListByWriter(writerId);
        return View(values);
    }

    [HttpGet]
    public IActionResult ComposeMessage()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ComposeMessage(Message2 message2)
    {
        var username = User.Identity?.Name;
        var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
        message2.SenderId = writerId;
        message2.ReceiverId = 5;
        message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        message2.MessageStatus = true;
        _message2Manager.TAdd(message2);
        return RedirectToAction("SendBox");
    } 
}