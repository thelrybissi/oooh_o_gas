using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Domain.Enums;

namespace ooohOGas.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navegação
        public Supplier? Supplier { get; set; }
        public Customer? Customer { get; set; }
    }
}
