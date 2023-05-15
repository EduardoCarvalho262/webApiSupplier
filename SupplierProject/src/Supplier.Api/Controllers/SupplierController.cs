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
        public List<SupplierType> GetAll()
        {
            var response = _supplierService.GetAllSuppliers();

            return response;
        }
    }
}
