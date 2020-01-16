using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ResilienceASP.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/ServerError")]
        public IActionResult ServerError()
        {
            return View();
        }

        [Route("Error/HttpError/{id}")]
        public IActionResult HttpError(int id)
        {
            return View(id);
        }
    }
}