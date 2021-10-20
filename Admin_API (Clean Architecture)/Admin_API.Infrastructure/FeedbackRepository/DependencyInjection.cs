using Microsoft.Extensions.DependencyInjection;
using Admin_API.Application.Gateway;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Admin_API.Infrastructure.FeedbackRepository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<FeedbackDbContext>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddHttpClient();
            services.AddScoped<IProfileDbContext>(optiont => (IProfileDbContext)optiont.GetService<FeedbackDbContext>());
            return services;
        }
    }
}
