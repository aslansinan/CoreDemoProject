using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class CategoryController : Controller
{
    private CategoryManager cm = new CategoryManager(new EfCategoryRepository());
    public IActionResult index()
    {
        var values = cm.GetList();
        return View(values);
    }
}