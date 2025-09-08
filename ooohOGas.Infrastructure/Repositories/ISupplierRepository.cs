using ooohOGas.Domain.Entities;

namespace ooohOGas.Infrastructure.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(Guid id);
        Task AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task<bool> DeleteAsync(Guid id);
    }
}
