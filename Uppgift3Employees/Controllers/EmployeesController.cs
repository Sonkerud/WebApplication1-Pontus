using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uppgift3Employees.Models;

namespace Uppgift3Employees.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesService service = new EmployeesService();
        [Route ("")]
        [Route ("Index")]
        public IActionResult Index()
        {
            //var arrayOfEmployees = service.GetAllEmployees();
            var hej = service.GetEmployees();
            return View(hej);
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

            service.AddEmployeeJson(employee);

            return RedirectToAction(nameof(Index));
        }

        [Route("employees/details/{id}")]
        //[HttpGet]
        public IActionResult Details(int id)
        {
            var employee = service.GetEmployeeById(id);
           
            return View(employee);
        }

    }
}