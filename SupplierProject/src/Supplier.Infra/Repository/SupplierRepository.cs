﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DeleteSupplier(int id)
        {
            var supplier = _supplierContext.Supplier.FirstOrDefault(x => x.Id == id);

            if (supplier == null)
            {
                return false;
            }

            _supplierContext.Supplier.Remove(supplier);
            await _supplierContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<SupplierType>> GetAllSuppliers()
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
            if(supplier == null)
            {
                throw new ArgumentNullException("Usuário vazio.");
            }

            _supplierContext.Supplier.Update(supplier);

            await SaveAsync();

            return supplier;
        }
    }
}
