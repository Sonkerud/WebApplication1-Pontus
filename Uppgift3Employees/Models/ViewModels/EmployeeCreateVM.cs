using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3Employees.Models.ViewModels
{
    public class EmployeeCreateVM
    {
        [Required(ErrorMessage = "Ange namn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ange E-mail")]
        public string Email { get; set; }
        [Display(Name = "What is 2+2?")]
        [Range(4,4)]
        public bool BotCheck { get; set; }
    }
}
