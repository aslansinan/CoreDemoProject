﻿using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

[AllowAnonymous]
public class RegisterUserController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterUserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserSignUpViewModel userSignUpViewModel)
    {
        if (ModelState.IsValid)
        {
            AppUser user = new AppUser()
            {
                Email = userSignUpViewModel.Mail,
                UserName = userSignUpViewModel.UserName,
                NameSurname = userSignUpViewModel.NameSurname,
            };
            var result = await _userManager.CreateAsync(user, userSignUpViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }

        return View(userSignUpViewModel);
    }
}