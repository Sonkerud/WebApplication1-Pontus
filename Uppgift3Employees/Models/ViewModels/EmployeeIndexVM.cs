using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3Employees.Models.ViewModels
{
    public class EmployeeIndexVM
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string Name { get; set; }
        [Display(Name="E-mail")]
        public string Email { get; set; }
        public bool ShowAsHighlighted { get {
         return Email.StartsWith("admin")
                ? true
                : false;
            } set { } }

    }
}
