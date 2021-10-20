using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Admin_API.Domain.Entities
{
    [Table("AspNetUsers")]
    public class User
    {
        //   public string Id { get; set; }
        [Key]
        public string UserName { get; set; }
        //  public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        //  public string NormalizedEmail { get; set; }
        //  public bool EmailConfirmed { get; set; }
        //   public string PasswordHash { get; set; }
        //  public string SecurityStamp { get; set; }
        //  public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        //  public bool PhoneNumberConfirmed { get; set; }
        // public bool TwoFactorEnabled { get; set; }
        //  public DateTimeOffset? LockoutEnd { get; set; }
        //   public bool LockoutEnabled { get; set; }
        //   public int AccessFailedCount { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        //  public string Role { get; set; }
    }
}
