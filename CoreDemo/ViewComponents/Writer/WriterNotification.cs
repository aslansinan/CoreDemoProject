﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer;

public class WriterNotification : ViewComponent
{
    private NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
    public IViewComponentResult Invoke()
    {
        var values = _notificationManager.GetList();
        return View(values);
    }
}