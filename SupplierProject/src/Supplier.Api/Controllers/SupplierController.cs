using Microsoft.AspNetCore.Mvc;
using Supplier.Domain.Models;
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

            return Ok(response);
        }

        [HttpGet("supplier")]
        public async Task<IActionResult> GetById([FromBody]int id)
        {
            var response = await _supplierService.GetSupplierById(id);

            return Ok(response);
        }

        [HttpPost("supplier")]
        public async Task<IActionResult> InsertSupplier([FromBody] SupplierType supplier)
        {
            var response = await _supplierService.InsertSupplier(supplier);

            if (response != null)
            {
                return Ok(response);
            }
            
            return BadRequest();
        }
    }
}
