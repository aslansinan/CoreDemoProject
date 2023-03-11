using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer;

public class WriterMessageNotification : ViewComponent
{
    MessageManager _messageManager = new MessageManager(new EfMessageRepository());

    public IViewComponentResult Invoke()
    {
        string p = "aslansinan586@gmail.com";
        //var values = _messageManager.GetInboxListByWriter(p);
        var values = _messageManager.GetList();
        return View(values);
    }
}