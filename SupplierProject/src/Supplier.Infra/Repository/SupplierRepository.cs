using Supplier.Domain.Models;
using Supplier.Infra.Context;
using Supplier.Infra.Interfaces;

namespace Supplier.Infra.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ISupplierContext _supplierContext;

        public SupplierRepository(ISupplierContext supplierContext)
        {
            _supplierContext = supplierContext;
        }

        public void DeleteSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierType> GetAllSuppliers()
        {
            return _supplierContext.Supplier.ToList();
        }

        public SupplierType GetSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertSupplier(SupplierType supplier)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplier(SupplierType supplier)
        {
            throw new NotImplementedException();
        }
    }
}
