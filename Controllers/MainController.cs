using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReenbitCamp_TestTask_backend.Models;
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
        public async Task<IActionResult> UploadFile([FromForm] UploadFileModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            var connectionString = _configuration.GetValue<string>("BlobStorage:ConnectionString");
            var containerName = _configuration.GetValue<string>("BlobStorage:ContainerName");

            try
            {
                string fileName = await _blobService.UploadFileToBlobAsync(model.File, containerName, connectionString, model.Email);

                return Ok($"The file \"{fileName}\" was successfully uploaded.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while uploading file to blob storage.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the file.");
            }
        }
    }
}
