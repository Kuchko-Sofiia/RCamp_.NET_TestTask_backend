using FluentValidation;
using ReenbitCamp_TestTask_backend.Models;

namespace ReenbitCamp_TestTask_backend.Validators
{
    public class UploadFileValidator : AbstractValidator<UploadFileModel>
    {
        private readonly string[] _allowedExtensions = { ".docx" };

        public UploadFileValidator()
        {
            RuleFor(x => x.File)
                .NotNull().WithMessage("File is required")
                .Must(x => HasValidExtension(x.FileName)).WithMessage($"Only .docx extension is allowed");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("Invalid email address");
        }
        private bool HasValidExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return _allowedExtensions.Contains(extension);
        }
    }
}
