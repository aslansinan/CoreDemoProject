using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents;

public class CommentsList: ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var values = new List<UserComment>
        {
            new UserComment()
            {
                ID = 1,
                UserName = "SİNAN"
            },
            new UserComment()
            {
                ID = 2,
                UserName = "Veli"
            },
            new UserComment()
            {
                ID = 3,
                UserName = "Ali"
            }
        };
        return View(values);
    }
}