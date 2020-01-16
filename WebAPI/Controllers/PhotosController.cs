using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class PhotosController : Controller
    {
        PhotosService service;

        public PhotosController(PhotosService service)
        {
            this.service = service;
        }

        [Route("")]
        [Route("photos")]
        public async Task<IActionResult> Index()
        {
            var model = await service.GetPhotosFromExternalApi();
            return View(model);
        }
    }
}