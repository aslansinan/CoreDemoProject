using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer;

public class WriterAboutOnDashboard : ViewComponent
{
    private WriterManager writerManager = new WriterManager(new EfWriterRepository());
    Context context = new Context();

    public IViewComponentResult Invoke()
    {
        var userMail = User.Identity?.Name;
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
            .FirstOrDefault();
        var values = writerManager.GetWriterById(writerId);
        return View(values);
    }
}