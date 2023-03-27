using System.Security.Claims;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public IActionResult index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> index(UserSignInViewModel appUser)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser.username, appUser.password, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("index", "Dashboard");
            }
            else
            {
                return RedirectToAction("index", "Login");
            }
        }

        return View();
    }

    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("index", "Login");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}