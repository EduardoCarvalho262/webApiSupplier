using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<SupplierType>> GetAllSuppliers()
        {
            return await _supplierContext.Supplier.ToListAsync();
        }

        public async Task<SupplierType> GetSupplier(int id)
        {
            if(id == 0)
            {
                throw new ArgumentException("Invalid supplier ID.");
            }

            var response = await _supplierContext.Supplier.FirstOrDefaultAsync(x => x.Id == id);

            if(response == null)
            {
                throw new Exception("Not Found supplier");
            }

            return response;
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
