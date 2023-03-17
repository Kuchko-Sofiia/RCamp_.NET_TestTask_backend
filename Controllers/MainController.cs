using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReenbitCamp_TestTask_backend.Services;

namespace ReenbitCamp_TestTask_backend.Controllers
{
    [Route("[controller]")]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IBlobService _blobService;

        public MainController(ILogger<MainController> logger, IConfiguration configuration, IBlobService blobService)
        {
            _logger = logger;
            _configuration = configuration;
            _blobService = blobService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] string? email)
        {
            //TODO: implement the action
            var connectionString = _configuration.GetValue<string>("BlobStorage:ConnectionString");
            var containerName = _configuration.GetValue<string>("BlobStorage:ContainerName");

            string fileName = _blobService.UploadFileToBlobAsync(file, containerName, connectionString).Result;

            return Ok($"Done. FileName: {fileName}; Email: {email}");
        }
    }
}
