using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;
[AllowAnonymous]
public class CommentController : Controller
{
    private CommentManager cm = new CommentManager(new EfCommentRepository());
    public IActionResult index()
    {
        return View();
    }
    [HttpGet]
    public PartialViewResult PartialAddComment()
    {
        return PartialView();
    }
    [HttpPost]
    public IActionResult PartialAddComment(Comment comment)
    {
        comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        comment.CommentStatus = true;
        comment.BlogId = 5;
        cm.CommentAdd(comment);
        Response.Redirect("/Blog/BlogReadAll/" + 1);
        return PartialView();
    }
    public PartialViewResult CommentListByBlog(int id)
    {
        var values = cm.GetList(id);
        return PartialView(values);
    }
}