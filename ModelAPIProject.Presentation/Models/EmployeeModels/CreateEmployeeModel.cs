using System.ComponentModel.DataAnnotations;
using TokenAPI.Domain.Entities;
using TokenAPI.Domain.Value_Objects;

namespace TokenAPI.Presentation.Models.EmployeeModels
{
    public class CreateEmployeeModel
    {
        [Required(ErrorMessage = "Please provide the employee's first name.")]
        [MaxLength(50, ErrorMessage = "The employee's first name can contain up to {1} characters.")]
        [MinLength(2, ErrorMessage = "The employee's first name cannot be less than {1} characters long.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "The employee's middle name can contain up to {1} characters.")]
        [MinLength(2, ErrorMessage = "The employee's middle name cannot be less than {1} characters long.")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Please provide the employee's first name.")]
        [MaxLength(50, ErrorMessage = "The employee's surname can contain up to {1} characters.")]
        [MinLength(2, ErrorMessage = "The employee's surname cannot be less than {1} characters long.")]
        public string Surname { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmission { get; set; }

        [Required(ErrorMessage = "Please inform the employee's Department ID.")]
        public Guid DepartmentID { get; set; }
    }
}
