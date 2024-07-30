using BusinessLogics.Helper;
using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DataAccessRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository<UserEntity,Guid>,UserRepository>();
            services.AddScoped<IHelper,Helper>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            return services;
        }
    }
}
