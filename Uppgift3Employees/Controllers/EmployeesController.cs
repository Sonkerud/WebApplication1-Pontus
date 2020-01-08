using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uppgift3Employees.Models;
using Uppgift3Employees.Models.Entities;

namespace Uppgift3Employees.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesService service;


        public EmployeesController(EmployeesService service)
        {
            this.service = service;
        }

        [Route ("")]
        [Route ("Index")]
        public IActionResult Index()
        {
            //var arrayOfEmployees = service.GetAllEmployees();
            var model = service.GetAllEmployees();
            return View(model);
        }

        [Route("employee/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route("employee/create")]
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

          //  service.AddEmployee(employee);

            return RedirectToAction(nameof(Index));
        }

        [Route("employees/details/{id}")]
        //[HttpGet]
        public IActionResult Details(int id)
        {
            var employee = service.GetEmployeeById(id);
           
            return View(employee);
        }

        [Route("employees/delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            service.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}