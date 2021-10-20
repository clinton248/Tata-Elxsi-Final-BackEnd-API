using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_API.Application.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Continent { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        public string Status { get; set; }
    }
}
