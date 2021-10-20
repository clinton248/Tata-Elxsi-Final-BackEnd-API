using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Authentication
{
    public class ApplicationUser : IdentityUser
    {

        public string Continent { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

    }
  }
