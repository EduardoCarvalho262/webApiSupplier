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

        public async Task<string> DeleteSupplier(int id)
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

            return response == null ? throw new Exception("Not Found supplier") : response;
        }

        public async Task<SupplierType> InsertSupplier(SupplierType supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException("Usuário vazio.");
            }

            _supplierContext.Supplier.Add(supplier);
            await SaveAsync();

            return supplier;
        }

        public Task SaveAsync()
        {
           return _supplierContext.SaveChangesAsync();
        }

        public async Task<SupplierType> UpdateSupplier(SupplierType supplier)
        {
            throw new NotImplementedException();
        }
    }
}
