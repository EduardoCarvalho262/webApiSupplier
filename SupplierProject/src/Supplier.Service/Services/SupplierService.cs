using Supplier.Domain.Models;
using Supplier.Service.Interfaces;

namespace Supplier.Service.Services
{
    public class SupplierService : ISupplierService
    {
        public List<SupplierType> GetAllSuppliers()
        {
            return new List<SupplierType>() { new SupplierType { Id = 1}};
        }
    }
}
