using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace TokenAPI.Presentation.Models.DepartmentModels
{
    public class CreateDepartmentModel
    {
        [Required(ErrorMessage = "Please provide the employee's first name.")]
        [MaxLength(50, ErrorMessage = "The department's name can contain up to {1} characters.")]
        [MinLength(2, ErrorMessage = "The department's name cannot be less than {1} characters long.")]
        public string Name { get; set; } = string.Empty;
    }
}
