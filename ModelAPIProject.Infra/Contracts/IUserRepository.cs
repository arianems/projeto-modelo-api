using ModelAPIProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Value_Objects;
using TokenAPI.Infra.Contracts;

namespace ModelAPIProject.Infra.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(Email email);
        Task<User> GetCredentials(Email email, string password);
    }
}
