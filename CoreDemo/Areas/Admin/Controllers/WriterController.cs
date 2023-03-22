using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class WriterController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddWriter(WriterClass writerClass)
    {
        writers.Add(writerClass);
        var jsonWriters = JsonConvert.SerializeObject(writerClass);
        return Json(jsonWriters);
    }

    public IActionResult WriterList()
    {
        var jsonWriters = JsonConvert.SerializeObject(writers);
        return Json(jsonWriters);
    }

    public IActionResult GetWriterById(int id)
    {
        var findwriter = writers.FirstOrDefault(x => x.Id == id);
        var jsonWriters = JsonConvert.SerializeObject(findwriter);
        return Json(jsonWriters);
    }

    public static List<WriterClass> writers = new List<WriterClass>()
    {
        new WriterClass
        {
            Id = 1,
            Name = "Teknolji",
        },
        new WriterClass
        {
            Id = 2,
            Name = "Spor",
        },
        new WriterClass
        {
            Id = 3,
            Name = "Müzik",
        }
    };
}