using EMS.BusinessLogics.Implementations;
using EMS.BusinessLogics.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.BusinessLogics
{
    public static class BusinessServiceRegistrations
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailProcessController,EmailProcessController>();
            return services;
        }
    }
}
