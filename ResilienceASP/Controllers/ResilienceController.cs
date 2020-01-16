using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResilienceASP.Models.ViewModels;

namespace ResilienceASP.Controllers
{
    public class ResilienceController : Controller
    {
        [Route("Home/Index")]
        [Route("")]

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/About")]
        public IActionResult About()
        {
            throw new Exception();
        }

        //[Route("resilience/Token")]
        //public IActionResult Token()
        //{
        //    return View();
        //}

        //[ValidateAntiForgeryToken]
        [HttpPost]
        [Route("resilience/Token")]
        public IActionResult Token(ResilienceVM model)
        {
            return RedirectToAction(nameof(Index));
        }


    }
}