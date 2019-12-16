using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uppgift3Employees.Models;
using Uppgift3Employees.Models.Entities;

namespace Uppgift3Employees.Controllers
{
    public class CompanyController : Controller
    {
        CompanyService service;

        public CompanyController(CompanyService service)
        {
            this.service = service;
        }

        [Route("/company")]
        [Route("/company/Index")]
        public IActionResult Index()
        {
            var model = service.GetAllCompanies();
            return View(model);
        }

        [Route("company/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
              

        [Route("company/create")]
        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }

            service.AddCompany(company);

            return RedirectToAction(nameof(Index));
        }

        [Route("company/details/{id}")]
        //[HttpGet]
        public IActionResult Details(int id)
        {
            var company = service.GetCompanyById(id);

            return View(company);
        }
    }
}