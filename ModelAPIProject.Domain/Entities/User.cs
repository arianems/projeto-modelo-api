using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Entities;
using TokenAPI.Domain.Value_Objects;

namespace ModelAPIProject.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Email Email { get; set; } = null!;
        public string Password { get; set; } = string.Empty;
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; } = null!;

        public User() { }

        public User(Guid id, Email email, string password, Guid employeeID)
        {
            Id = id;
            Email = email;
            Password = password;
            EmployeeID = employeeID;
        }
    }
}
