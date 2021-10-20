using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Authentication
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage ="User Name is required for changing Password")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Plese Enter Current Password")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage ="Please Enter New Password")]
        public string NewPassword{ get; set; }
        [Required(ErrorMessage ="Please Confirm Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
