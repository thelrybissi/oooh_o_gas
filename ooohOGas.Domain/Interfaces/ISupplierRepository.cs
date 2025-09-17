using ooohOGas.Domain.Entities;

namespace ooohOGas.Infrastructure.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier?> GetByCnpjAsync(string Cpnj);
        Task<Supplier> UpdateAsync(Supplier supplier);
    }
}
