using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Infra.Contexts;
using TokenAPI.Infra.Contracts;

namespace TokenAPI.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SQLServerContext _context;

        protected BaseRepository(SQLServerContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T obj)
        {
            var result = _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Guid id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result != null)
            {
                _context.Set<T>().Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public virtual async Task<T> GetById(Guid id) 
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task Update(T obj)
        {
           _context.Set<T>().Update(obj);
            await _context.SaveChangesAsync();

        }
    }
}
