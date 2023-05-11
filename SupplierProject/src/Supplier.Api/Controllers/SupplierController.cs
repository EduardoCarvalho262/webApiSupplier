using Microsoft.AspNetCore.Mvc;

namespace Supplier.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class SupplierController : ControllerBase
    {
        [HttpGet]
        public string HelloWorld() 
        {
            return "Hello World!";    
        }
    }
}
