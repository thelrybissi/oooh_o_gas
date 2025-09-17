using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ooohOGas.Application.Dtos.Accounts;
using ooohOGas.Application.Dtos.Customers;
using ooohOGas.Application.Dtos.SuppliersDto;
using ooohOGas.Application.Interfaces;
using ooohOGas.Application.Services;

namespace ooohOGas.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService service)
        {
            _accountService = service;
        }

        [HttpPost("create-supplier")]
        public async Task<IActionResult> CreateSupplierAccount([FromBody] CreateSupplierAccountRequest request)
        {
            var result = await _accountService.CreateSupplierAccountAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        [HttpPost("create-customer")]
        public async Task<IActionResult> CreateCustomerAccount([FromBody] CreateCustomerAccountRequest request)
        {
            var result = await _accountService.CreateCustomerAccountAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAccount(Guid userId)
        {
            
            var result = await _accountService.DeleteAccountAsync(userId);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok();
        }

    }
}
