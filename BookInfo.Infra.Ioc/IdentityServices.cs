using BookInfo.Application.identity;
using BookInfo.Domain.Entities.Identities;
using BookInfo.Infra.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Ioc
{
    public static class IdentityServices
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                //options.SignIn.RequireConfirmedEmail = true;
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                //options.Lockout.MaxFailedAccessAttempts = 3;
            })

               .AddErrorDescriber<ApplicationIdentityErrorDescriber>()
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<DataContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(opt =>
             {
                 opt.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKey"])),
                     TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["EncrypKey"])),
                     RequireSignedTokens = true,
                     RequireExpirationTime = true,
                     ValidateLifetime = true,
                     ValidateIssuer = false,
                     ValidateAudience = false,


                 };
             });
            services.AddAuthorization(opt => opt.AddPolicy("Admin", policy => policy.RequireRole("Admin")));

            return services;
        }
    }
}
