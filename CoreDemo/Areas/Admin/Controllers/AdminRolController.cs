using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;
[Area("Admin")] 
public class AdminRolController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;

    public AdminRolController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        var values = _roleManager.Roles.ToList();
        return View(values);
    }
    [HttpGet]
    public IActionResult AddRole()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
    {
        if (ModelState.IsValid)
        {
            AppRole role = new AppRole
            {
                Name = roleViewModel.Name
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
        return View(roleViewModel);
    }
    [HttpGet]
    public IActionResult UpdateRole(int id)
    {
        var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        RoleUpdateViewModel roleUpdateViewModel = new RoleUpdateViewModel
        {
            Id = values.Id,
            Name = values.Name
        };
        return View(roleUpdateViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRole(RoleUpdateViewModel roleUpdateViewModel)
    {
        var values = _roleManager.Roles.FirstOrDefault(x => x.Id == roleUpdateViewModel.Id);
        values.Name = roleUpdateViewModel.Name;
        var result = await _roleManager.UpdateAsync(values);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }

        return View(roleUpdateViewModel);
    }

    public async Task<IActionResult> DeleteRole(int id)
    {
        var vales = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        var result = await _roleManager.DeleteAsync(vales);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }

        return Empty;
    }
}