using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityASPPontus.Models;
using IdentityASPPontus.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityASPPontus.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<User> UserMgr { get; }
        public SignInManager<User> SignInMgr { get; }
        public RoleManager<IdentityRole> RoleMgr { get; set; }
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {

            UserMgr = userManager;
            SignInMgr = signInManager;
            RoleMgr = roleManager;
        }

        [Route("")]
        [Route("Index")]

        public IActionResult Index()
        {
            return View();
        }

        [Route("Account/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Account/Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserVM model)
        {
                User user = await UserMgr.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    user = new User();
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;

                    IdentityResult result = await UserMgr.CreateAsync(user, model.Password);
                    ViewBag.Message = "User was created";

                }
                else
                {
                    return View(model);
                }
            
          
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(UserVM model)
        {
            var result = await SignInMgr.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Members));
            }
            else
            {
                ViewBag.Result = "result is: " + result.ToString();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Account/Members")]
        public IActionResult Members()
        {
            return View();
        }
    }
}