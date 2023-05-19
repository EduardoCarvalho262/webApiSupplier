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

        public async Task<IEnumerable<SupplierType>> GetAllSuppliers()
        {
            return  await _supplierRepository.GetAllSuppliers();
        }


        public async Task<SupplierType> GetSupplierById(int id)
        {
            return await _supplierRepository.GetSupplier(id);
        }
    }
}
