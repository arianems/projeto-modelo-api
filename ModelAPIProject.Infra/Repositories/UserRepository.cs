using Microsoft.EntityFrameworkCore;
using ModelAPIProject.Domain.Entities;
using ModelAPIProject.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Value_Objects;
using TokenAPI.Infra.Contexts;
using TokenAPI.Infra.Repositories;

namespace ModelAPIProject.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SQLServerContext _context;
        public UserRepository(SQLServerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(Email email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Address.ToUpper() == email.Address.ToUpper());
            return user;

        }

        public async Task<User> GetCredentials(Email email, string password)
        {
            return await _context.Users.DefaultIfEmpty().FirstAsync(u => u.Email.Equals(email) && u.Password == password);
        }
    }
}
