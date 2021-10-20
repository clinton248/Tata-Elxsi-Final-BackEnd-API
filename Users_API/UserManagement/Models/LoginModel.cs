using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName Can't be Empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cant be empty")]
        public string Password { get; set; }
       
    }
}
