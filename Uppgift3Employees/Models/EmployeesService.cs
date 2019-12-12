using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Uppgift3Employees.Models
{
    public class EmployeesService
    {
        static int idCounter = 1;

        public static List<Employee> employeesList = new List<Employee>()
        {
            new Employee{Id = idCounter++, Name="Alexander", Email="alexander.sonerud@hotmail.com"},
            new Employee{Id = idCounter++, Name="Martin", Email="martin@hotmail.com"},
            new Employee{Id = idCounter++, Name="Viktor", Email="viktor@hotmail.com"}
        };

        public void AddEmployee(Employee employee)
        {
            employee.Id = idCounter++;
            employeesList.Add(employee);

        }
        public void AddEmployeeJson(Employee employee, List<Employee> list)
        {
            employee.Id = idCounter++;
            list.Add(employee);
        }

        public Employee[] GetAllEmployees()
        {
            return employeesList.OrderBy(e=>e.Name).ToArray();
        }
        public Employee GetEmployeeById(int id) {
            
            var employees = GetEmployees();
            
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
            employee.Id = employeesJson.Count() + 1;
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
        
        
    }
}
