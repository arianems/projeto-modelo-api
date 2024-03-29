﻿using System.ComponentModel.DataAnnotations;

namespace TokenAPI.Presentation.Models.EmployeeModels
{
    public class UpdateEmployeeModel
    {
        [Required(ErrorMessage = "Please provide the employee's ID.")]
        public Guid Id { get; set; }

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

        [Required(ErrorMessage = "A valid email address must be provided.")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        [MaxLength(90, ErrorMessage = "The employee's email can have up to {1} characters.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please inform the employee's Department ID.")]
        public Guid DepartmentID { get; set; }
    }
}
