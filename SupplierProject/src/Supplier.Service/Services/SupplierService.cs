using AutoMapper;
using Supplier.Domain.DTOs;
using Supplier.Domain.Models;
using Supplier.Infra.Interfaces;
using Supplier.Service.Interfaces;

namespace Supplier.Service.Services
{
    public class SupplierService : ISupplierService
    {

        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            return await _supplierRepository.DeleteSupplier(id);
        }

        public async Task<IEnumerable<SupplierTypeDTO>> GetAllSuppliers()
        {
            try
            {
                var suppliers = await _supplierRepository.GetAllSuppliers();
                var response = _mapper.Map<IEnumerable<SupplierTypeDTO>>(suppliers);
                return response;
            }
            catch (Exception ex)
            {
                //TODO Logar erro
                return new List<SupplierTypeDTO>().AsEnumerable();
            }
           
        }

        public async Task<SupplierTypeDTO> GetSupplierById(int id)
        {
            try
            {
                var supplier = await _supplierRepository.GetSupplier(id);
                var response = _mapper.Map<SupplierTypeDTO>(supplier);
                return response;
            }
            catch (Exception ex)
            {
                //TODO Logar erro
                return new SupplierTypeDTO();
            }
        }

        public Task<SupplierTypeDTO> InsertSupplier(SupplierTypeDTO supplier)
        {
            try
            {
                var newSupplier = _mapper.Map<SupplierType>(supplier);
                var response = _supplierRepository.InsertSupplier(newSupplier);
                var result = _mapper.Map<SupplierTypeDTO>(response);

                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                //TODO Logar erro
                return Task.FromResult(new SupplierTypeDTO());
            }
        }

        public Task<SupplierTypeDTO> UpdateSupplier(SupplierTypeDTO newSupplier)
        {
            try
            {
                var supplierToUpdate = _mapper.Map<SupplierType>(newSupplier);
                var response = _supplierRepository.InsertSupplier(supplierToUpdate);
                var result = _mapper.Map<SupplierTypeDTO>(response);

                return Task.FromResult(result);
            }
            catch (Exception ex)
            { 
                //TODO Logar erro
                return Task.FromResult(new SupplierTypeDTO());
            }
        }
    }
}
