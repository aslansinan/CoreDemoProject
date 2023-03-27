using CoreDemo.Areas.Admin.Models;
using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;
[Area("Admin")] 
public class AdminRolController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;


    public AdminRolController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
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
    
    public IActionResult UserRoleList()
    {
        var values = _userManager.Users.ToList();
        return View(values);
    }

    [HttpGet]
    public async Task<IActionResult> AssignRole(int id)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
        var roles = _roleManager.Roles.ToList();

        TempData["Userid"] = user.Id;
        var userRoles = await _userManager.GetRolesAsync(user);

        List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
        foreach (var item in roles)
        {
            RoleAssignViewModel m = new RoleAssignViewModel();
            m.RoleId = item.Id;
            m.Name = item.Name;
            m.Exists = userRoles.Contains(item.Name);
            model.Add(m);
        }
        return View(model);
    }
}