using AutoMapper;
using Supplier.Domain.DTOs;
using Supplier.Domain.Models;

namespace Supplier.Domain.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierType, SupplierTypeDTO>();
            CreateMap<SupplierTypeDTO, SupplierType>();
        }
    }
}
