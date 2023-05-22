using Microsoft.EntityFrameworkCore;
using Supplier.Domain.Models;
using Supplier.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Infra.Context
{
    public class SupplierContext : DbContext, ISupplierContext
    {
        public SupplierContext(DbContextOptions<SupplierContext> options): base(options)
        { 
        }

        public DbSet<SupplierType> Supplier { get; set; }

        Task<int> ISupplierContext.SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
