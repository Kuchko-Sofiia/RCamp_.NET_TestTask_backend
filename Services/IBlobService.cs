namespace ReenbitCamp_TestTask_backend.Services
{
    public interface IBlobService
    {
        Task<string> UploadFileToBlobAsync(IFormFile file, string containerName, string connectionString, string emailAddress);
    }
}
