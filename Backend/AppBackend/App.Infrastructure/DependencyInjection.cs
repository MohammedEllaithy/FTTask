using App.Application.Common.Interfaces.Authentication;
using App.Application.Common.Interfaces.Presistence;
using App.Application.Common.Interfaces.Services;
using App.Domain.Entities;
using App.Infrastructure.Authentication;
using App.Infrastructure.Data;
using App.Infrastructure.External;
using App.Infrastructure.Presistence;
using App.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration)

        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("connMSSQL")));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(ConnectionStrings.connMSSQL)));
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddHostedService<ExternalUserService>();
            //        services.AddIdentity<User, IdentityRole<Guid>>()
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            //services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer("Server=DESKTOP-MV029GE;Database=AppDB;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddDefaultIdentity<User>();

            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }

    }
}
