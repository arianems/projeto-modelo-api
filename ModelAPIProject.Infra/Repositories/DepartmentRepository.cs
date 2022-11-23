using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Entities;
using TokenAPI.Infra.Contexts;
using TokenAPI.Infra.Contracts;

namespace TokenAPI.Infra.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly SQLServerContext _context;
        public DepartmentRepository(SQLServerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Department> GetByName(string name)
        {
            return await _context.Departments.DefaultIfEmpty().FirstAsync(d => d.Name == name);
            
        }
    }
}
