using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StateDemoAsp.Models;
using StateDemoAsp.Models.ViewModels;

namespace StateDemoAsp.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IMemoryCache cache;
        private readonly SettingsService service;

        public SettingsController(IMemoryCache cache, SettingsService service)
        {
            this.cache = cache;
            this.service = service;
        }

        [Route("settings/display")]

        public IActionResult Index()
        {
            var model = service.GetModel();
            return View(model);
        }

        [Route("")]
        [Route("settings/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("settings/create")]
        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            service.CreateModel(model);
            return RedirectToAction(nameof(Index));
        }
    }
}