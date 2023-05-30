using Supplier.Domain.DTOs;
using Supplier.Domain.Models;

namespace Supplier.Service.Interfaces
{
    public interface ISupplierService
    {
        public Task<IEnumerable<SupplierTypeDTO>> GetAllSuppliers();
        public Task<SupplierTypeDTO> GetSupplierById(int id);
        public Task<SupplierTypeDTO> InsertSupplier(SupplierTypeDTO supplier);
        public Task<SupplierTypeDTO> UpdateSupplier(SupplierTypeDTO supplier);
        public Task<bool> DeleteSupplier(int id);
    }
}
