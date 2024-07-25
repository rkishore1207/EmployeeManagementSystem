using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;

namespace BusinessLogics
{
    public static class BusinessRegistrations
    {
        public static IServiceCollection AddBusinessServices(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
