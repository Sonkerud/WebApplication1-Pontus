using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift3Employees.Models.Entities;

namespace Uppgift3Employees.Models.ViewModels
{
    public class EmpComp
    {
        public List<Employee> EmpList { get; set; }
        public Company Company { get; set; }
    }
}
