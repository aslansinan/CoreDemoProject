using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category;

public class CategoryListDashboard : ViewComponent
{
    private CategoryManager cm = new CategoryManager(new EfCategoryRepository());

    public IViewComponentResult Invoke()
    {
        var values = cm.GetList();
        return View(values);
    }
}