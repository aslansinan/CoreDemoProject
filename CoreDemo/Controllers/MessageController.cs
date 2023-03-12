using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

[AllowAnonymous]
public class MessageController : Controller
{
    private Message2Manager _message2Manager = new Message2Manager(new EfMessage2Repository());

    public IActionResult InBox()
    {
        int id = 3;
        var values = _message2Manager.GetInboxListByWriter(id);
        //var values = _message2Manager.GetList();
        return View(values);
    }

    public IActionResult MessageDetails(int id)
    {
        var value = _message2Manager.TGetById(id);
        return View(value);
    }
}