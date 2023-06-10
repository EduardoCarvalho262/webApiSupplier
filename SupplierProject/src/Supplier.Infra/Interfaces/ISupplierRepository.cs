using Supplier.Domain.Models;

namespace Supplier.Infra.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<SupplierType>> GetAllSuppliers();
        Task<SupplierType> GetSupplier(int id);
        Task<SupplierType> InsertSupplier(SupplierType supplier);
        Task<SupplierType> UpdateSupplier(SupplierType supplier);
        Task<bool> DeleteSupplier(int id);
        Task SaveAsync();
    }
}
