using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;
[Area("Admin")]
public class ChartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CategoryChart()
    {
        List<CategoryClass> list = new List<CategoryClass>();
        list.Add(new CategoryClass
        {
            CategoryName = "Teknolji",
            CategoryCount = 10
        });
        list.Add(new CategoryClass
        {
            CategoryName = "Spor",
            CategoryCount = 44
        });
        list.Add(new CategoryClass
        {
            CategoryName = "Müzik",
            CategoryCount = 13
        });
        return Json(new { jsonList = list });
    }
}