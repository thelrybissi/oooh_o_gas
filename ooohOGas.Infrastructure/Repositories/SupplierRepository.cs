using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ooohOGas.Domain.Entities;
using ooohOGas.Infrastructure.Persistence;

namespace ooohOGas.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly OoohOGasDbContext _context;

        public SupplierRepository(OoohOGasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetByCnpjAsync(String cnpj)
        {
            return await _context.Suppliers.FindAsync(cnpj);
        }

        public async Task<Supplier> UpdateAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
    }
}
