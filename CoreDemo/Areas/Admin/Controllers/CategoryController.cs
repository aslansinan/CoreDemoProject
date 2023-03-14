using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
    public IActionResult Index(int page=1)
    {
        var values = _categoryManager.GetList().ToPagedList(page,3);
        return View(values);
    }

    [HttpGet]
    public IActionResult AddCategory()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        CategoryValidator bv = new CategoryValidator();
        ValidationResult results = bv.Validate(category);
        if (results.IsValid)
        {
            category.CategoryStatus = true;
            _categoryManager.TAdd(category);
            return RedirectToAction("Index", "Category");
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }

        return View();
    }

    public IActionResult CategoryDelete(int id)
    {
        var categoryvalue = _categoryManager.TGetById(id);
        _categoryManager.TDelete(categoryvalue);
        return RedirectToAction("Index");
    }
}