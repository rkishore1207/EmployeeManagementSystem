using AzureServices;
using EMS.BusinessLogics;
using EMS.DataAccessLayer;
using EMS.Utilities.ConfigService;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddScoped<IConfigurationService, ConfigurationService>();
        services.AddBusinessServices().AddDataServices().AddAzureServices();
    })
    .Build();

host.Run();
