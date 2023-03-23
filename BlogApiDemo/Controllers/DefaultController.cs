using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DefaultController : ControllerBase
{
    [HttpGet]
    public IActionResult EmployeeList()
    {
        using var c = new Context();
        var values = c.Employees.ToList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult EmployeeAdd(Employee employee)
    {
        using var c = new Context();
        c.Add(employee);
        c.SaveChangesAsync();
        return Ok();
    }
}