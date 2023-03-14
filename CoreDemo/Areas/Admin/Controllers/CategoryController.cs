using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;

public class CategoryController : Controller
{
    private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
    [Area("Admin")]
    public IActionResult Index()
    {
        var values = _categoryManager.GetList();
        return View(values);
    }
}