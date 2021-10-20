using Admin_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_API.Application.Gateway
{
    public interface IProfileDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
