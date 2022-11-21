using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenAPI.Infra.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Create(T obj);
        Task Delete(Guid id);
        Task Update(T obj);

        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}
