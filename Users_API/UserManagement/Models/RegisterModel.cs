using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Authentication
{

    public class RegisterModel
    {
        [Required(ErrorMessage ="UserName Can't be Empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Can't be Empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Continent can't be empty")]
        public string Continent { get; set; }
        [Required(ErrorMessage = "Country  can't be empty")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Language can't be empty")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Address can't be empty")]
        public string Address { get; set; }
        [Required(ErrorMessage = "PhoneNumber can't be empty")]

        public string PhoneNumber { get; set; }

    }
}
