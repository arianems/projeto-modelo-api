using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Entities;

namespace TokenAPI.Infra.Contracts
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<Department> GetByName(string name);
    }
}
