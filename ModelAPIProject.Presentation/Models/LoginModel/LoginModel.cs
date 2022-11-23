using System.ComponentModel.DataAnnotations;

namespace ModelAPIProject.Presentation.Models.LoginModel
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage = "Invalid email.")]
        [Required(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; } = string.Empty;
    }
}
