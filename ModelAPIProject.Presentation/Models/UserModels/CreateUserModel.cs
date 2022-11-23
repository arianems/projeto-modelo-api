using System.ComponentModel.DataAnnotations;
using TokenAPI.Domain.Value_Objects;

namespace ModelAPIProject.Presentation.Models.UserModels
{
    public class CreateUserModel
    {
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Required(ErrorMessage = "Please provide an email address.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a valid password.")]
        [MaxLength(128, ErrorMessage = "The password can be up to {1} characters long.")]
        [MinLength(6, ErrorMessage = "The password must be at least {1} characters long.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm the password.")]
        [Compare("Password", ErrorMessage = "Passwords do not match. Try again.")]
        public string PasswordConfirmation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the associated employee's ID.")]
        public Guid EmployeeID { get; set; }
    }
}
