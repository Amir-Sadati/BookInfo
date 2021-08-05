using BookInfo.Application.Interfaces;
using BookInfo.Application.Services;
using BookInfo.Infra.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Ioc
{
    public static class CustomeServices
    {
        public static IServiceCollection AddCustomeServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenService, JwtTokenservice>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
