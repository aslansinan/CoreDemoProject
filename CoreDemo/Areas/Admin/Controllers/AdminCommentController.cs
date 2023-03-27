using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminCommentController : Controller
{
    private CommentManager _commentManager = new CommentManager(new EfCommentRepository());
    public IActionResult Index()
    {
        var values = _commentManager.GetCommentWithBlog();
        return View(values);
    }
}