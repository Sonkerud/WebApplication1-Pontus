using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3Employees.Models.ViewModels
{
    public class CustomersCreateVM
    {
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Entar a company name")]
        
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
