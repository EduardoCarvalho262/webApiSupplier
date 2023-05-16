using Supplier.Domain.Models;
using Supplier.Infra.Interfaces;

namespace Supplier.Infra.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        public void DeleteSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierType> GetAllSuppliers()
        {
            return new List<SupplierType>() { new SupplierType { Id = 2 } }.AsEnumerable<SupplierType>();
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
