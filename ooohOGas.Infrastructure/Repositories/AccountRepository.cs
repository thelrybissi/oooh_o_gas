using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ooohOGas.Domain.Entities;
using ooohOGas.Domain.Interfaces;
using ooohOGas.Infrastructure.Persistence;

namespace ooohOGas.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly OoohOGasDbContext _context;

        public AccountRepository(OoohOGasDbContext context)
        {
            _context = context;
        }

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return await _context.Accounts
                .Include(a => a.Supplier)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account?> GetByUsernameAsync(string username)
        {
            return await _context.Accounts
                .Include(a => a.Supplier)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.Username == username);
        }

        public async Task<Account> AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Account account)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}
