using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Application.Dtos.Customers;

namespace ooohOGas.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDto>> GetAllAsync();
        Task<CustomerResponseDto?> GetByIdAsync(Guid id);
        Task<CustomerResponseDto?> UpdateAsync(Guid id, CustomerUpdateDto dto);

    }
}
