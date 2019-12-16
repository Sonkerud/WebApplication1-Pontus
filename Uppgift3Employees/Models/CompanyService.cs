using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift3Employees.Models.Entities;

namespace Uppgift3Employees.Models
{
    public class CompanyService
    {
        private readonly EmployeeContext context;

        public CompanyService(EmployeeContext context)
        {
            this.context = context;
        }
        public Company[] GetAllCompanies()
        {
            return context.Company.ToArray();
        }

        public void AddCompany(Company company)
        {
            context.Company.Add(company);
            context.SaveChanges();
        }

        public Company GetCompanyById(int id)
        {

            var employees = GetAllCompanies();

            return employees.Single(e => e.Id == id);
        }
    }
}
