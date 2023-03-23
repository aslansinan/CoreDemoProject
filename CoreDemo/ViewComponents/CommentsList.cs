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
                Id = 1,
                UserName = "SİNAN"
            },
            new UserComment()
            {
                Id = 2,
                UserName = "Veli"
            },
            new UserComment()
            {
                Id = 3,
                UserName = "Ali"
            }
        };
        return View(values);
    }
}