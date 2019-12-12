using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uppgift1FavoritBandASP.Models;

namespace Uppgift1FavoritBandASP.Controllers
{
    public class BandsController : Controller
    {
        BandsService service = new BandsService();

        [Route("")]
        public IActionResult Index()
        {
            var model = service.GetAllBands();
            return View(model);
        }

        [Route("bands/details/{id}")]
        public IActionResult Details(int id)
        {
            var model = service.GetBandById(id);
            return View(model);
        }
    }
}