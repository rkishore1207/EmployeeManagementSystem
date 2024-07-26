using AutoMapper;
using BusinessLogics.Implementations;
using BusinessLogics.Interfaces;
using BusinessLogics.Mapper;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using System.Reflection;

namespace BusinessLogics
{
    public static class BusinessRegistrations
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserProcessController, UserProcessController>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
