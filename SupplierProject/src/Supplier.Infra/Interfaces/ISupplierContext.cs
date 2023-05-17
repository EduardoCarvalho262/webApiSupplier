using Microsoft.EntityFrameworkCore;
using Supplier.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Infra.Interfaces
{
    public interface ISupplierContext
    {
        DbSet<SupplierType> Supplier { get; set; }
        int SaveChanges();
    }
}
