using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Domain.Entities;

namespace ooohOGas.Infrastructure.Repositories
{
    public class InMemorySupplierRepository : ISupplierRepository
    {
        private readonly List<Supplier> _suppliers = new();

        public Task<IEnumerable<Supplier>> GetAllAsync()
            => Task.FromResult(_suppliers.AsEnumerable());

        public Task<Supplier?> GetByIdAsync(Guid id)
            => Task.FromResult(_suppliers.FirstOrDefault(x => x.Id == id));

        public Supplier AddAsync(Supplier supplier)
        {
            _suppliers.Add(supplier);
            return _suppliers[0];
        }

        public Supplier UpdateAsync(Supplier supplier)
        {
            var index = _suppliers.FindIndex(x => x.Id == supplier.Id);
            if (index >= 0) _suppliers[index] = supplier;
            return _suppliers[index];
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var entity = _suppliers.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _suppliers.Remove(entity);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
