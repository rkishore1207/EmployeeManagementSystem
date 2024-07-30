using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ems.Functions
{
    public class SendEmail
    {
        private readonly ILogger<SendEmail> _logger;
        private readonly string? _StorageConnectionString;

        public SendEmail(ILogger<SendEmail> logger,IConfiguration configuration)
        {
            _logger = logger;
            _StorageConnectionString = configuration.GetValue<string>("StorageAccount");
        }

        [Function(nameof(SendEmail))]
        public void Run([QueueTrigger("ems.email.queue", Connection = _StorageConnectionString)] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
