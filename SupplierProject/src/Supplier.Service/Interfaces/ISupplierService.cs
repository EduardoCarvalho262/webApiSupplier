using Supplier.Domain.Models;

namespace Supplier.Service.Interfaces
{
    public interface ISupplierService
    {
        public Task<IEnumerable<SupplierType>> GetAllSuppliers();
        public Task<SupplierType> GetSupplierById(int id);
        public Task<SupplierType> InsertSupplier(SupplierType supplier);
    }
}
