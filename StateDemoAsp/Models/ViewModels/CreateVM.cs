using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDemoAsp.Models.ViewModels
{
    public class CreateVM
    {
        [Required(ErrorMessage ="Ange Mail")]
        [Display(Name = "Support E-Mail")]

        public string SupportEmail { get; set; }
        [Required(ErrorMessage = "Ange företagsnamn")]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
        public string  Name { get; set; }
    }
}
