using Azure.Storage.Blobs;
using AzureServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AzureServices.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly string? _ContainerName;
        private readonly string? _StorageConnectionString;

        public BlobStorageService(IConfiguration configuration)
        {
            _ContainerName = configuration.GetValue<string>("AzureCredentials:ContainerName");
            _StorageConnectionString = configuration.GetValue<string>("StorageAccountConnection");
        }

        private async Task<BlobContainerClient> GetBlobContainerClient()
        {
            BlobContainerClient containerClient = new BlobContainerClient(_StorageConnectionString, _ContainerName);
            await containerClient.CreateIfNotExistsAsync();
            return containerClient;
        }

        public async Task UploadAsync(string fileName, IFormFile formFile)
        {
            var containerClient = await GetBlobContainerClient();
            var blobName = $"{fileName}-{Path.GetFileName(formFile.FileName)}";
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                memoryStream.Position = 0;
                var blob = containerClient.GetBlobClient(blobName);
                await blob.UploadAsync(memoryStream);
            }
        }
    }
}
