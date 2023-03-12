using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers;

[AllowAnonymous]
public class BlogController : Controller
{
    BlogManager bm = new BlogManager(new EfBlogRepository());
    CategoryManager cm = new CategoryManager(new EfCategoryRepository());
    Context context = new Context(); 

    public IActionResult index()
    {
        var values = bm.GetBlogListWithCategory();
        return View(values);
    }

    public IActionResult BlogReadAll(int id)
    {
        ViewBag.i = id;
        var values = bm.GetBlogById(id);
        return View(values);
    }

    public IActionResult BlogListByWriter()
    {
        var userMail = User.Identity?.Name;
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
            .FirstOrDefault();
        var values = bm.GetListWithCategoryByWriterBm(writerId);
        return View(values);
    }

    [HttpGet]
    public IActionResult BlogAdd()
    {
        List<SelectListItem> categoryvalues = (from x in cm.GetList()
            select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();
        ViewBag.cv = categoryvalues;
        return View();
    }

    [HttpPost]
    public IActionResult BlogAdd(Blog p)
    {
        var userMail = User.Identity?.Name;
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
            .FirstOrDefault();
        BlogValidator bv = new BlogValidator();
        ValidationResult results = bv.Validate(p);
        if (results.IsValid)
        {
            p.BlogStatus = true;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerId;
            bm.TAdd(p);
            return RedirectToAction("BlogListByWriter", "Blog");
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

    public IActionResult DeleteBlog(int id)
    {
        var blogvalue = bm.TGetById(id);
        bm.TDelete(blogvalue);
        return RedirectToAction("BlogListByWriter");
    }

    [HttpGet]
    public IActionResult EditBlog(int id)
    {
        List<SelectListItem> categoryvalues = (from x in cm.GetList()
            select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();
        ViewBag.cv = categoryvalues;
        var blogvalue = bm.TGetById(id);
        return View(blogvalue);
    }
    [HttpPost]
    public IActionResult EditBlog(Blog blog)
    {
        var userMail = User.Identity?.Name;
        var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
            .FirstOrDefault();
        blog.WriterID = writerId;
        blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        blog.BlogStatus = true;
        bm.TUpdate(blog);
        return RedirectToAction("BlogListByWriter");
    }
}