using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Application.Dtos.Accounts;
using ooohOGas.Application.Dtos.Customers;
using ooohOGas.Application.Dtos.Suppliers;
using ooohOGas.Application.Dtos.SuppliersDto;
using ooohOGas.Application.Interfaces;
using ooohOGas.Domain.Entities;
using ooohOGas.Domain.Enums;
using ooohOGas.Domain.Interfaces;
using ooohOGas.Infrastructure.Persistence;
using ooohOGas.Infrastructure.Repositories;

namespace ooohOGas.Application.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ICustomerRepository _customerRepository;

        public AccountService(
            IAccountRepository accountRepository,
            ISupplierRepository supplierRepository,
            ICustomerRepository customerRepository)
        {
            _accountRepository = accountRepository;
            _supplierRepository = supplierRepository;
            _customerRepository = customerRepository;
        }

        // Create Account Supplier
        public async Task<ServiceResult<AccountResponse>> CreateSupplierAccountAsync(CreateSupplierAccountRequest request)
        {
            var existingSupplier = await _supplierRepository.GetByCnpjAsync(request.Cnpj);
            if (existingSupplier != null)
                return ServiceResult<Account>.Failure("Fornecedor já cadastrado com esse CNPJ.");

            var account = new Account
            {
                Username = request.Username,
                PasswordHash = HashPassword(request.Password),
                Role = UserRole.Supplier,
            };

            await _accountRepository.AddAsync(account);

            var supplier = new Supplier
            {
                Account = account,
                CorporateName = request.CorporateName,
                TradeName = request.TradeName,
                Cnpj = request.Cnpj,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address
            };

            account.Supplier = supplier;

            await _accountRepository.AddAsync(account);

            return ServiceResult<AccountResponse>.Ok(new AccountResponse
            {
                UserId = account.Id,
                Username = account.Username,
                Role = account.Role.ToString()
            });
        }

        // Create Account Customer
        public async Task<ServiceResult<AccountResponse>> CreateCustomerAccountAsync(CreateCustomerAccountRequest request)
        {
            if (await _customerRepository.GetByCpfAsync(request.Cpf))
                throw new InvalidOperationException("Customer já cadastrado.");

            var account = new Account
            {
                Username = request.Username,
                PasswordHash = HashPassword(request.Password),
                Role = UserRole.Customer,
            };

            var customer = new Customer
            {
                Account = account,
                Name = request.Name,
                Cpf = request.Cpf,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address
            };

            account.Customer = customer;

            await _accountRepository.AddAsync(account);

            return ServiceResult<AccountResponse>.Ok(new AccountResponse
            {
                UserId = account.Id,
                Username = account.Username,
                Role = account.Role.ToString()
            });
        }

        // Delete Account on cascade
        public async Task<ServiceResult<bool>> DeleteAccountAsync(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.Supplier)
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) throw new InvalidOperationException("User não encontrado.");

            _context.Users.Remove(user); // Cascade vai deletar Supplier/Customer
            await _context.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true);
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }
    }
}
