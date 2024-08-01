using Azure.Storage.Queues;
using AzureServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AzureServices.Services
{
    public class QueueStorageService : IQueueStorageService
    {
        private readonly string? _queueName;
        private readonly string? _StorageConnectionString;
        public QueueStorageService(IConfiguration configuration)
        {
            _queueName = configuration.GetValue<string>("AzureCredentials:QueueName");
            _StorageConnectionString = configuration.GetValue<string>("StorageAccountConnection");
        }

        public async Task SendMessageToQueue<T>(T message)
        {
            QueueClient queueClient = new QueueClient(_StorageConnectionString, _queueName, new QueueClientOptions() { MessageEncoding = QueueMessageEncoding.Base64 });
            await queueClient.CreateIfNotExistsAsync();
            var queueMessage = JsonConvert.SerializeObject(message);
            await queueClient.SendMessageAsync(queueMessage);
        }
    }
}
