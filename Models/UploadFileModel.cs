using System.ComponentModel.DataAnnotations;

namespace ReenbitCamp_TestTask_backend.Models
{
    public class UploadFileModel
    {
        public IFormFile File { get; set; }
        public string Email { get; set; }
    }
}
