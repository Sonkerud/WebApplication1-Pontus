using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uppgift2HundASP.Models;

namespace Uppgift2HundASP.Controllers
{
    public class DogsController : Controller
    {
        DogsService service = new DogsService();

        [Route("")]
        [Route("dogs/index")]
        public IActionResult Index()
        {
            var list = service.GetAllDogs();
            return View(list);
        }


        [Route("dogs/delete/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            service.DeleteDog(id);
            return RedirectToAction(nameof(Index));
        }


        [Route("dogs/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new DogImager());
        }

        [Route("dogs/create")]
        [HttpPost]
        public IActionResult Create(Dog dog)
        {
            service.AddDog(dog);
            return RedirectToAction(nameof(Index));
        }

        [Route("dogs/edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doggy = service.GetDogById(id);
            return View(doggy);
        }

        [Route("dogs/edit/{id}")]
        [HttpPost]
        public IActionResult Edit(Dog dog)
        {
            service.EditDog(dog);
            return RedirectToAction(nameof(Index));
        }

        [Route("dogs/list/")]
        [HttpPost]
        public IActionResult List(Dog[] dog)
        {
            //service.EditDog(dog);
            return RedirectToAction(nameof(Index));
        }
    }
}