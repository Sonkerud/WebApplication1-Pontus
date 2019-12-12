using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_Pontus.Models
{

    //Mappar mot tabell i databas
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string City { get; set; }

    }
}
