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
        public Email Email { get; set; } = null!;
        public string Password { get; set; } = string.Empty;
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; } = null!;

        public User() { }

        public User(Email email, string password, Guid employeeID)
        {
            Email = email;
            Password = password;
            EmployeeID = employeeID;
        }
    }
}
