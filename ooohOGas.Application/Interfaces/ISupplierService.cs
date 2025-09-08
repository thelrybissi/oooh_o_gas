using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Application.DTOs;

namespace ooohOGas.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>> GetAllAsync();
        Task<SupplierDto?> GetByIdAsync(Guid id);
        Task<SupplierDto> CreateAsync(SupplierDto dto);
        Task<SupplierDto?> UpdateAsync(SupplierDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
