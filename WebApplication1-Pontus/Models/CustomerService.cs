using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_Pontus.Models
{
    public class CustomerService
    {
        static int idCounter = 1;
        //Representerar data i vår "databas"
        List<Customer> customers = new List<Customer>()
        {
            new Customer{Id = idCounter++, CompanyName = "Academy", City="Stockholm"},
            new Customer{Id = idCounter++, CompanyName = "Frasses", City="Hudiksvall"},
            new Customer{Id = idCounter++, CompanyName = "Academic Work", City="Stockholm"},
            new Customer{Id = idCounter++, CompanyName = "ICA", City="Malmö"}
        };

        public Customer[] GetAllCustomers()
        {
            return customers.OrderBy(c=>c.CompanyName).ToArray();
        }

        public void AddCustomer(Customer customer)
        {
            customer.Id = idCounter++;
            customers.Add(customer);

        }
    }
}
