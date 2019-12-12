using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3Employees.Models
{
    public class Employee
    {
       
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Ange namn")]
        public string Name { get; set; }
        //[HardCodedEmail("acme.com")]
        [Required(ErrorMessage = "Ange Email")]
        [Display (Name = "E-mail")]
        [EmailAddress(ErrorMessage="Not correct email-input ")]
        public string  Email { get; set; }
    }
}
