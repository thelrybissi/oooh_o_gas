using Microsoft.AspNetCore.Mvc;
using ooohOGas.Application.Dtos.Suppliers;
using ooohOGas.Application.Dtos.SuppliersDto;
using ooohOGas.Application.Interfaces;

namespace ooohOGas.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var supplier = await _service.GetByIdAsync(id);
            return supplier == null ? NotFound() : Ok(supplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSupplierDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }

    }
}
