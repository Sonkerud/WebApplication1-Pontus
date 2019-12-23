using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uppgift3Employees.Models;
using Uppgift3Employees.Models.Entities;
using Uppgift3Employees.Models.ViewModels;

namespace Uppgift3Employees.Controllers
{
    public class CompanyController : Controller
    {
        CompanyService service;
        EmployeesService serviceEmp;

        public CompanyController(CompanyService service, EmployeesService serviceEmp)
        {
            this.service = service;
            this.serviceEmp = serviceEmp;
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
            EmpComp empComp = new EmpComp();
            var company = service.GetCompanyById(id);
            empComp.Company = company;
            //empComp.EmpList = serviceEmp.GetAllEmployees().Where(x => x.CompanyId == company.Id).ToList();

            return View(empComp);
        }
    }
}