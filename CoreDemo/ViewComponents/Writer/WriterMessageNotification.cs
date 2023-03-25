using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer;

public class WriterMessageNotification : ViewComponent
{
    Context context = new Context();
    Message2Manager _message2Manager = new Message2Manager(new EfMessage2Repository());

    public IViewComponentResult Invoke()
    {
        var username = User.Identity?.Name;
        var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
        var values = _message2Manager.GetInboxListByWriter(writerId);
        return View(values);
    }
}