using Supplier.Domain.Models;

namespace Supplier.Service.Interfaces
{
    public interface ISupplierService
    {
        public List<SupplierType> GetAllSuppliers();
    }
}
