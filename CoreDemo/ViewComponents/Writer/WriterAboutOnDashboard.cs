using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer;

public class WriterAboutOnDashboard : ViewComponent
{
    private WriterManager _writerManager = new WriterManager(new EfWriterRepository());
    Context context = new Context();
    public IViewComponentResult Invoke()
    {
        var username = User.Identity?.Name;
        if (username != null)
        {
            ViewBag.v = username;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
                .FirstOrDefault();
            var values = _writerManager.GetWriterById(writerId);
            return View(values);
        }

        return null;
    }
}