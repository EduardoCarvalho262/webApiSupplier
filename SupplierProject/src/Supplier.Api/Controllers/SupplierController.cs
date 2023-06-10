using Microsoft.AspNetCore.Mvc;
using Supplier.Domain.DTOs;
using Supplier.Domain.Models;
using Supplier.Domain.Responses;
using Supplier.Service.Interfaces;

namespace Supplier.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SupplierController : ControllerBase
    {

        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }


        [HttpGet("suppliers")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _supplierService.GetAllSuppliers();

            if(response.Message.Contains("Erro:"))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("supplier")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _supplierService.GetSupplierById(id);

            if (response.Message.Contains("Erro:"))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("supplier")]
        public async Task<IActionResult> InsertSupplier([FromBody] SupplierTypeDTO supplier)
        {
            var response = await _supplierService.InsertSupplier(supplier);

            if (response.Message.Contains("Erro:"))
                return BadRequest(response);

            return Created("/api/supplier/" + response.Response.FirstOrDefault().Id, response);
        }

        [HttpPut("supplier")]
        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierTypeDTO supplier)
        {
            var response = await _supplierService.UpdateSupplier(supplier);

            if (response.Message.Contains("Erro:"))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("supplier")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var response = await _supplierService.DeleteSupplier(id);

            if (response)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
