using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Entities;

namespace TokenAPI.Infra.Contracts
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> GetByEmail(string email);
        Task<IEnumerable<Employee>> GetByDepartment(Guid departmentID);
    }
}
