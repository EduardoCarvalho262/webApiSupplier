using Supplier.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Domain.Responses
{
    public class SupplierResponse
    {
        public string? Message { get; set; }
        public IList<SupplierTypeDTO>? Response { get; set; }
    }
}
