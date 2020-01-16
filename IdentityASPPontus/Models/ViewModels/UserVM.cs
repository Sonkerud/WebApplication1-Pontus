using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityASPPontus.Models.ViewModels
{
    public class UserVM
    {
        [Required(ErrorMessage = "User name")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "First name")]

        public string FirstName { get; set; }
        [Display(Name = "Last name")]

        [Required(ErrorMessage = "Last name")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        

        public string Password { get; set; }
    }
}
