using Admin_API.Application.AdminAppLayer.Usecases.UserList;
using Admin_API.Application.Gateway;
using AutoMapper.Configuration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Admin_API.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserLogics, UserLogics>();
            return services;
        }
    }
}
