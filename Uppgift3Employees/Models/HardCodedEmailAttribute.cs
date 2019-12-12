using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Uppgift3Employees.Models
{
    public class HardCodedEmailAttribute : ValidationAttribute
    {
        string correctValue;
        

        public HardCodedEmailAttribute(string correctValue)
        {
            this.correctValue = correctValue;
        }

        public override bool IsValid (object value)
        {
            if (value.ToString().EndsWith("acme.com"))
            {
                if (value?.ToString() == null || correctValue == null)
                {
                    return false;
                }
                else if (value.ToString() == correctValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            return false;

        }
    }
}
