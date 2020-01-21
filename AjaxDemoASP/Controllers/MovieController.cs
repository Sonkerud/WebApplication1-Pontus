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

   
        [Route("Movies/{id}")]

        public IActionResult GetMovie(int id)
        {
            var movie = service.GetMovieById(id);
            return PartialView("_MovieBox",movie);
        }

        [Route("Movies")]

        public IActionResult Movies()
        {
            var movie = service.GetMovieVM();
            return Json(movie);
        }

        [Route("MovieData/{id}")]
        public IActionResult MoviesData(int id)
        {
            var movie = service.GetMovieById(id);
            return Json(movie);
        }
    }
}