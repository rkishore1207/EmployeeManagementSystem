using Microsoft.AspNetCore.Http;

namespace AzureServices.Interfaces
{
    public interface IBlobStorageService
    {
        Task UploadAsync(string fileName, Stream stream);
    }
}