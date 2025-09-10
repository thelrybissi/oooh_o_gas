using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Domain.Enums;

namespace ooohOGas.Application.Dtos.Customers
{
    public class CustomerCreateDto
    {
        public UserRole UserRole { get; set; } = UserRole.Customer;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
    }
}
