using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityASPPontus.Models;
using IdentityASPPontus.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityASPPontus.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor httpContext;

     

        public UserManager<User> UserMgr { get; }
        public SignInManager<User> SignInMgr { get; }
        public RoleManager<IdentityRole> RoleMgr { get; set; }
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor httpContext)
        {

            UserMgr = userManager;
            SignInMgr = signInManager;
            RoleMgr = roleManager;
            this.httpContext = httpContext;

        }

        [Route("")]
        [Route("Index")]

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Members));
            } else
            {
                return View();
            }
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
            if (model.UserName!=null)
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

                    if (!result.Succeeded)
                    {
                        TempData["Result"] = $"{result.ToString()}";
                    }

                }
                else
                {
                    TempData["Result"] = "Username Exists";

                    return View(model);
                }
            }
                
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(UserVM model)
        {
            if (model.UserName != null)
            {
                var result = await SignInMgr.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                        return RedirectToAction(nameof(Members));
                }
                else
                {
                    TempData["Result"] =  result.ToString();
                }
            }
           
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Account/Logout")]
        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Account/Members")]
        public async Task<IActionResult> Members()
        {
            var  user = await UserMgr.GetUserAsync(httpContext.HttpContext.User);

            return View(new UserVM {FirstName = user.FirstName, LastName = user.LastName, Email = user.Email,UserName = user.UserName });
        }

        [HttpGet]
        [Route("Account/Edit")]
        public async Task<IActionResult> Edit()
        {
            var user = await UserMgr.GetUserAsync(httpContext.HttpContext.User);
            return View(new UserVM { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, UserName = user.UserName });
        }

        [HttpPost]
        [Route("Account/Edit")]
        public async Task<IActionResult> Edit(UserVM model)
        {
            var user = await UserMgr.GetUserAsync(httpContext.HttpContext.User);
            var userId =  UserMgr.GetUserId(httpContext.HttpContext.User);
            
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            //User user = new User { FirstName = model.FirstName, LastName = model.LastName, UserName = model.UserName, Email = model.Email };
            await UserMgr.UpdateAsync(user);
            return RedirectToAction(nameof(Members));
        }
    }
}