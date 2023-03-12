using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

[AllowAnonymous]
public class NotificationController : Controller
{
    private NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AllNotification()
    {
        var values = _notificationManager.GetList();
        return View(values);
    }
}