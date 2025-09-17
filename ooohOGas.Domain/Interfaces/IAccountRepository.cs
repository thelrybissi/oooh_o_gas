using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Domain.Entities;

namespace ooohOGas.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid id);
        Task<Account?> GetByUsernameAsync(string username);
        Task<Account> AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Account account);
    }
}
