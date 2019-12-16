using System;
using System.Collections.Generic;

namespace Uppgift3Employees.Models.Entities
{
    public partial class Company
    {
        public Company()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
