using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    public class EmailCheck
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
