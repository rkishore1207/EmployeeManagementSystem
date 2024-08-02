using EMS.DataAccessLayer.Helpers;
using EMS.DataAccessLayer.Interfaces;
using EMS.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.DataAccessLayer
{
    public static class DataServiceRegistrations
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IHelper, Helper>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            return services;
        }
    }
}
