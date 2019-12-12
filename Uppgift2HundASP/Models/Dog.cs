using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgift2HundASP.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ange namn:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ange ålder:")]
        public int Age { get; set; }
        public string ImgSrc { get; set; }

        public override string ToString()
        {
            return $"{Name} är {Age} år gammal";
        }
    }
}
