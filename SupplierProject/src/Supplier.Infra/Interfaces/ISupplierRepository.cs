using Supplier.Domain.Models;

namespace Supplier.Infra.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<SupplierType>> GetAllSuppliers();
        SupplierType GetSupplier(int id);
        void InsertSupplier(SupplierType supplier);
        void UpdateSupplier(SupplierType supplier);
        void DeleteSupplier(int id);
        void Save();
    }
}
