using Microsoft.Extensions.Configuration;

namespace EMS.Utilities.ConfigService
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? SqlConnectionString => _configuration.GetValue<string>("SqlConnectionString");
    }
}
