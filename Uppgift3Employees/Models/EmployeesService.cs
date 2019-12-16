using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Uppgift3Employees.Models.Entities;

namespace Uppgift3Employees.Models
{
    public class EmployeesService
    {
        private readonly EmployeeContext context;

        public EmployeesService(EmployeeContext context)
        {
            this.context = context;
        }
        public Employee[] GetAllEmployees()
        {
            return context.Employee.ToArray();
        }

        public void AddEmployee(Employee employee)
        {
            context.Employee.Add(employee);
            context.SaveChanges();
        }
 
        public Employee GetEmployeeById(int id) {
            
            var employees = GetAllEmployees();
            
            return employees.Single(e => e.Id == id);
        } 

        public List<Employee> GetEmployees()
        {
            using (var jsonFileReader = File.OpenText(@"C:\Users\Alexander\source\repos\WebApplication1-Pontus\Uppgift3Employees\wwwroot\data\employees.json"))
            {
                
            var hej = JsonSerializer.Deserialize<Employee[]>(jsonFileReader.ReadToEnd());
            return hej.ToList();
            }
        }

        public void AddEmployeeJson(Employee employee)
        {
            var employeesJson = GetEmployees();
            employee.Id = employeesJson.Max(x=> x.Id) + 1;
            employeesJson.Add(employee);
          
            using (var outputStream = File.OpenWrite(@"C:\Users\Alexander\source\repos\WebApplication1-Pontus\Uppgift3Employees\wwwroot\data\employees.json"))
            {
                JsonSerializer.Serialize<IEnumerable<Employee>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    employeesJson
                );
            }
        }

        public void DeleteEmployeeJson(int id)
        {
            var employeesJson = GetEmployees();
            var employeeToDelete = employeesJson.Single(e => e.Id == id);

            employeesJson.Remove(employeeToDelete); 

            using (var outputStream = File.OpenWrite(@"C:\Users\Alexander\source\repos\WebApplication1-Pontus\Uppgift3Employees\wwwroot\data\employees.json"))
            {
                JsonSerializer.Serialize<IEnumerable<Employee>>(
                    new Utf8JsonWriter(outputStream),
                    employeesJson
                );
            }
        }
        public void DeleteEmployee(int id)
        {
            var employeesJson = GetAllEmployees();
            var employeeToDelete = employeesJson.Single(e => e.Id == id);
            context.Employee.Remove(employeeToDelete);
            context.SaveChanges(); 
        }
    }
}
