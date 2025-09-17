using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Application.Dtos.Accounts;

namespace ooohOGas.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResult<AccountResponse>> CreateSupplierAccountAsync(CreateSupplierAccountRequest request);
        Task<ServiceResult<AccountResponse>> CreateCustomerAccountAsync(CreateCustomerAccountRequest request);
        Task<ServiceResult<bool>> DeleteAccountAsync(Guid userId);
    }
}
