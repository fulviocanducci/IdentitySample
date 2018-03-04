using IdentitySample.Application.Api.Interfaces;
using IdentitySample.Application.Api.Services;
using IdentitySample.CrossCutting.Identity.Models;
using IdentitySample.Domain.Interfaces;
using IdentitySample.Domain.Interfaces.Repository;
using IdentitySample.Infra.Data.Context;
using IdentitySample.Infra.Data.Repository;
using IdentitySample.Infra.Data.UoW;
using IdentitySample.Infra.Identity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IdentitySample.Infra.IoC.Bootstrappers
{
    public static class ApiBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddScoped<ISignInManager<ApplicationUser>, CustomSignInManager>();
            services.AddScoped<IUserManager<ApplicationUser>, CustomUserManager>();

            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IdentitySampleDbContext>();

            // Indra - Identity
            services.AddTransient<ISmsSender, SmsService>();
            services.AddTransient<IEmailSender, EmailService>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
