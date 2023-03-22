using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;

namespace ReenbitCamp_TestTask_backend.Services
{
    public class BlobService : IBlobService
    {
        public async Task<string> UploadFileToBlobAsync(IFormFile file, string containerName, string connectionString, string emailAddress)
        {
            var blobContainerClient = new BlobContainerClient(connectionString, containerName);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);

            var fileName = $"{Guid.NewGuid().ToString()}-{file.FileName}";

            var blobClient = blobContainerClient.GetBlobClient(fileName);

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders
                    {
                        ContentType = file.ContentType
                    },
                    Metadata = new Dictionary<string, string>
                    {
                        { "emailAddress", emailAddress }
                    }
                });
            }

            return fileName;
        }
    }
}
