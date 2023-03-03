using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class CommentController : Controller
{
    private CommentManager cm = new CommentManager(new EfCommentRepository());
    public IActionResult index()
    {
        return View();
    }

    public PartialViewResult PartialAddComment()
    {
        return PartialView();
    }
    public PartialViewResult CommentListByBlog(int id)
    {
        var values = cm.GetList(id);
        return PartialView(values);
    }
}