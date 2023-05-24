using Supplier.Domain.Models;
using Supplier.Infra.Interfaces;
using Supplier.Service.Interfaces;

namespace Supplier.Service.Services
{
    public class SupplierService : ISupplierService
    {

        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            return await _supplierRepository.DeleteSupplier(id);
        }

        public async Task<IEnumerable<SupplierType>> GetAllSuppliers()
        {
            return  await _supplierRepository.GetAllSuppliers();
        }


        public async Task<SupplierType> GetSupplierById(int id)
        {
            try
            {
                return await _supplierRepository.GetSupplier(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<SupplierType> InsertSupplier(SupplierType supplier)
        {
            if(supplier == null)
                throw new ArgumentNullException(nameof(supplier));

            var response = _supplierRepository.InsertSupplier(supplier);

            return response;

        }

        public Task<SupplierType> UpdateSupplier(SupplierType newSupplier)
        {
            if (newSupplier == null)
                throw new ArgumentNullException(nameof(newSupplier));

            var response = _supplierRepository.UpdateSupplier(newSupplier);

            return response;
        }
    }
}
