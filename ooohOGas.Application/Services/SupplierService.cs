using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooohOGas.Application.DTOs;
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

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(x => new SupplierDto
            {
                Id = x.Id,
                CorporateName = x.CorporateName,
                TradeName = x.TradeName,
                Cnpj = x.Cnpj,
                Email = x.Email,
                Phone = x.Phone
            });
        }

        public async Task<SupplierDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new SupplierDto
            {
                Id = entity.Id,
                CorporateName = entity.CorporateName,
                TradeName = entity.TradeName,
                Cnpj = entity.Cnpj,
                Email = entity.Email,
                Phone = entity.Phone
            };
        }

        public async Task<SupplierDto> CreateAsync(SupplierDto dto)
        {
            var entity = new Supplier
            {
                CorporateName = dto.CorporateName,
                TradeName = dto.TradeName,
                Cnpj = dto.Cnpj,
                Email = dto.Email,
                Phone = dto.Phone
            };

            await _repository.AddAsync(entity);

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<SupplierDto?> UpdateAsync(SupplierDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return null;

            entity.CorporateName = dto.CorporateName;
            entity.TradeName = dto.TradeName;
            entity.Cnpj = dto.Cnpj;
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;

            await _repository.UpdateAsync(entity);

            return dto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

