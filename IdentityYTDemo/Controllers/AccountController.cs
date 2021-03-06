﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityYTDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityYTDemo.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserMgr { get; }
        public SignInManager<AppUser> SignInMgr { get; }
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
           
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        public async Task<IActionResult> Login()
        {
            var result = await SignInMgr.PasswordSignInAsync("TestUser", "Test123?", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is: " + result.ToString();
            }

         

            return View();

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already registered";

                AppUser user = await UserMgr.FindByNameAsync("TestUser2");
                if (user == null)
                {
                    user = new AppUser();
                    user.UserName = "TestUser2";
                    user.Email = "TestUser2@test.com";
                    user.FirstName = "John2";
                    user.LastName = "Doe2";

                    IdentityResult result = await UserMgr.CreateAsync(user, "Test123?");
                    ViewBag.Message = "User was created";

                }
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }
            return View();
        }
       
    }
}