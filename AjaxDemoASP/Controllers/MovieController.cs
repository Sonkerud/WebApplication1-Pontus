using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjaxDemoASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxDemoASP.Controllers
{
    public class MovieController : Controller
    {
        MoviesServices service = new MoviesServices();

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(int id)
        //{
        //    var movie = service.GetMovieById(id);
        //    return View(movie);
        //}

        [HttpPost]
        [Route("Index/{id}")]

        public IActionResult Index(int id)
        {
            var movie = service.GetMovieById(id);
            return PartialView(movie);
        }


    }
}