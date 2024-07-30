namespace AzureServices.Interfaces
{
    public interface IQueueStorageService
    {
        Task SendMessageToQueue<T>(T message);
    }
}