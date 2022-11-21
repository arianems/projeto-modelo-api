using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Entities;
using TokenAPI.Infra.Contexts;
using TokenAPI.Infra.Contracts;

namespace TokenAPI.Infra.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly SQLServerContext _context;

        public EmployeeRepository(SQLServerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetByDepartment(Guid departmentID)
        {
            var result = await _context.Employees
                .Include(d => d.Department)
                .Where(e => e.DepartmentID == departmentID).ToListAsync();

            return result;
        }

        public async Task<Employee> GetByEmail(string email)
        {
            var result = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email.Address == email);
            return result;
        }
    }
}
