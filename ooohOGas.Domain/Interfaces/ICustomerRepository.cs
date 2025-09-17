using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Domain.Entities;

namespace ooohOGas.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByCpfAsync(string Cpf);
        Task<Customer> UpdateAsync(Customer customer);
    }
}
