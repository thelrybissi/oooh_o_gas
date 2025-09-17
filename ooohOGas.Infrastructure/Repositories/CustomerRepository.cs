using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Domain.Entities;
using ooohOGas.Infrastructure.Persistence;

namespace ooohOGas.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OoohOGasDbContext _context;

        public CustomerRepository(OoohOGasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Supplier?> GetByCpfAsync(String cnpj)
        {
            return await _context.Customers.FindAsync(cnpj);
        }

        public async Task<Supplier> UpdateAsync(Supplier supplier)
        {
            _context.Customers.Update(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
    }
}
