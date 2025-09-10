using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Application.Dtos.Suppliers;
using ooohOGas.Application.Dtos.SuppliersDto;

namespace ooohOGas.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierResponseDto>> GetAllAsync();
        Task<SupplierResponseDto?> GetByIdAsync(Guid id);
        Task<SupplierResponseDto> CreateAsync(CreateSupplierDto dto);
        Task<SupplierResponseDto?> UpdateAsync(Guid id, UpdateSupplierDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
