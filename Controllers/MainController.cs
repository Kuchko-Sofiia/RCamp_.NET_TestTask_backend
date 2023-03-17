using Microsoft.AspNetCore.Mvc;

namespace ReenbitCamp_TestTask_backend.Controllers
{
    [Route("[controller]")]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] string? email)
        {
            //TODO: implement the action
            return Ok($"Done. FileName: {file.FileName}; Email: {email}");
        }
    }
}
