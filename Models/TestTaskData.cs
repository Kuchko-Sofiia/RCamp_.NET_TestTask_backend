using System.ComponentModel.DataAnnotations;

namespace ReenbitCamp_TestTask_backend.Models
{
    public class TestTaskData
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
    }
}
