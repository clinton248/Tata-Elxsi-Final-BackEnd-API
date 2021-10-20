using Admin_API.Application.DTOs;
using Admin_API.Application.Gateway;
using Admin_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Admin_API.Infrastructure.FeedbackRepository
{
    public class FeedbackDbContext : DbContext, IProfileDbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options)
        {

        }
       protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<FeedbackRepository>().HasNoKey();
          base.OnModelCreating(builder);
        }

        public virtual DbSet<FeedbackDto> feedbackEntity { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
