using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ooohOGas.Application.Dtos.Customers;
using ooohOGas.Application.Interfaces;
using ooohOGas.Domain.Entities;
using ooohOGas.Infrastructure.Repositories;

namespace ooohOGas.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Cpf = c.Cpf,
                Email = c.Email,
                Phone = c.Phone
            });
        }

        public async Task<CustomerResponseDto?> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return customer == null
                ? null
                : new CustomerResponseDto { 
                    Id = customer.Id, 
                    Name = customer.Name, 
                    Email = customer.Email,
                    Phone = customer.Phone, 
                    Address =  customer.Address, 
                    Cpf = customer.Cpf };
        }

        public async Task<CustomerResponseDto> CreateAsync(CustomerCreateDto dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                Cpf = dto.Cpf
            };

            var result = await _customerRepository.AddAsync(customer);

            return new CustomerResponseDto { 
                Id = result.Id,
                Name = result.Name,
                Email = result.Email,
                Phone = result.Phone,
                Address = result.Address,
                Cpf = result.Cpf 
            };
                
        }


        public async Task<CustomerResponseDto?> UpdateAsync(Guid id, CustomerUpdateDto dto)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return null;

            customer.Name = dto.Name;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.Address = dto.Address;

            var result = await _customerRepository.UpdateAsync(customer);

            return new CustomerResponseDto
            {
                Id = result.Id,
                Name = result.Name,
                Email = result.Email,
                Phone = result.Phone,
                Address = result.Address,
                Cpf = result.Cpf
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _customerRepository.DeleteAsync(id);
        }
    }
}
