using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Application.Dtos.Suppliers;
using ooohOGas.Application.Dtos.SuppliersDto;
using ooohOGas.Application.Interfaces;
using ooohOGas.Domain.Entities;
using ooohOGas.Infrastructure.Repositories;

namespace ooohOGas.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SupplierResponseDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(x => new SupplierResponseDto
            {
                Id = x.Id,
                CorporateName = x.CorporateName,
                TradeName = x.TradeName,
                Cnpj = x.Cnpj,
                Email = x.Email,
                Phone = x.Phone,
                Address = x.Address
            });
        }

        public async Task<SupplierResponseDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new SupplierResponseDto
            {
                Id = entity.Id,
                CorporateName = entity.CorporateName,
                TradeName = entity.TradeName,
                Cnpj = entity.Cnpj,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address
            };
        }

        public async Task<SupplierResponseDto> CreateAsync(CreateSupplierDto dto)
        {
            var entity = new Supplier
            {
                CorporateName = dto.CorporateName,
                TradeName = dto.TradeName,
                Cnpj = dto.Cnpj,
                Email = dto.Email,
                Phone = dto.Phone, 
                Address = dto.Address
            };

            var result = await _repository.AddAsync(entity);
            if (result == null) return new SupplierResponseDto();

            var response = new SupplierResponseDto
            {
                Id = result.Id,
                CorporateName = result.CorporateName,
                TradeName = result.TradeName,
                Cnpj = result.Cnpj,
                Email = result.Email,
                Phone = result.Phone,
                Address = result.Address
            };
            
            return response;
        }

        public async Task<SupplierResponseDto?> UpdateAsync(Guid id, UpdateSupplierDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.CorporateName = dto.CorporateName;
            entity.TradeName = dto.TradeName;
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.Address = dto.Address;

            var result = await _repository.UpdateAsync(entity);
            var response = new SupplierResponseDto
            {
                Id = result.Id,
                CorporateName = result.CorporateName,
                TradeName = result.TradeName,
                Cnpj = result.Cnpj,
                Email = result.Email,
                Phone = result.Phone,
                Address = result.Address
            };

            return response;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

