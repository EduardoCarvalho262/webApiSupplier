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

        public void DeleteSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SupplierType>> GetAllSuppliers()
        {
            return await _supplierContext.Supplier.ToListAsync();
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
