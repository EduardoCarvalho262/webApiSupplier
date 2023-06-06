using Supplier.Domain.DTOs;
using Supplier.Domain.Models;
using Supplier.Domain.Responses;

namespace Supplier.Service.Interfaces
{
    public interface ISupplierService
    {
        public Task<SupplierResponse> GetAllSuppliers();
        public Task<SupplierResponse> GetSupplierById(int id);
        public Task<SupplierResponse> InsertSupplier(SupplierTypeDTO supplier);
        public Task<SupplierResponse> UpdateSupplier(SupplierTypeDTO supplier);
        public Task<bool> DeleteSupplier(int id);
    }
}
