using Azure.Storage.Blobs;
using AzureServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;

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
            BlobContainerClient blobContainer = new BlobContainerClient(_StorageConnectionString, _ContainerName);
            await blobContainer.CreateIfNotExistsAsync();
            return blobContainer;
        }

        public async Task UploadAsync(string fileName, Stream stream)
        {
            var blobContainer = await GetBlobContainerClient();
            var blobClient = blobContainer.GetBlobClient(fileName);
            stream.Position = 0;
            await blobClient.UploadAsync(stream);            
        }
    }
}
