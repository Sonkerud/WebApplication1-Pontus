using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1_Pontus.Models;

namespace WebApplication1_Pontus.Controllers
{
    public class CustomersController : Controller
    {
        CustomerService service;

        public CustomersController(CustomerService service)
        {
            this.service = service;
        }

        [Route("")]
        public IActionResult Index()
        {
            var model = service.GetAllCustomers();
            return View(model);
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            var customerNew = customer;
            service.AddCustomer(customerNew);
            return RedirectToAction(nameof(Index));
        }

        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            return Content($"Show details about special customer nr {id} here");
        }
    }
}