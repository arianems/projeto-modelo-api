using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Value_Objects;

namespace TokenAPI.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public FullName Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public Email Email { get; set; } = null!;

        public Guid DepartmentID { get; set; }
        public Department Department { get; set; } = null!;

        public Employee() { }
        public Employee(Guid id, FullName name, DateTime dateOfBirth, DateTime dateOfAdmission, Email email, Guid departmentId)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            DateOfAdmission = dateOfAdmission;
            Email = email;
            DepartmentID = departmentId;
        }
    }
}
