using AzureServices.Interfaces;
using AzureServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AzureServices
{
    public static class AzureServiceRegistrations
    {
        public static IServiceCollection AddAzureServices(this IServiceCollection services)
        {
            services.AddScoped<IQueueStorageService, QueueStorageService>();
            services.AddScoped<IBlobStorageService, BlobStorageService>();
            return services;
        }
    }
}
