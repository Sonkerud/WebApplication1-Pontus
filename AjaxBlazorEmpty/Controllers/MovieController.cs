using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AjaxBlazorEmpty.Controllers
{
    public class MovieController : Controller
    {
        [Route("")]
        [Route("Index")]

        public IActionResult Index()
        {
            return View();
        }
    }
}