using BusinessLogics.Implementations;
using BusinessLogics.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using System.Reflection;

namespace BusinessLogics
{
    public static class BusinessRegistrations
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserProcessController, UserProcessController>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IEmailProcessController, EmailProcessController>();
            services.AddScoped<IAdminProcessController, AdminProcessController>();
            return services;
        }
    }
}
