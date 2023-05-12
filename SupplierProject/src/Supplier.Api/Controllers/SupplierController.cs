using Microsoft.AspNetCore.Mvc;
using Supplier.Domain.Models;

namespace Supplier.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SupplierController : ControllerBase
    {
        [HttpGet("suppliers")]
        public List<SupplierType> GetAll()
        {
            return new List<SupplierType> { new SupplierType { Id = 1 } };    
        }
    }
}
