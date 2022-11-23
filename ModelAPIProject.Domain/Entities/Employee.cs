using ModelAPIProject.Domain.Entities;
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
        public Guid DepartmentID { get; set; }

        #region Navigation properties
        public Department Department { get; set; } = null!;
        public User? User { get; set; }

        #endregion
        public Employee() { }
        public Employee(Guid id, FullName name, DateTime dateOfBirth, DateTime dateOfAdmission, Guid departmentId, Guid? userID)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            DateOfAdmission = dateOfAdmission;
            DepartmentID = departmentId;
        }
    }
}
