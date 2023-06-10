using AutoMapper;
using Supplier.Domain.DTOs;
using Supplier.Domain.Models;
using Supplier.Domain.Responses;
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

        public async Task<SupplierResponse> GetAllSuppliers()
        {
            try
            {
                var suppliers = await _supplierRepository.GetAllSuppliers();
                var response = _mapper.Map<List<SupplierTypeDTO>>(suppliers);

                var result = new SupplierResponse { Message = "Todos fornecedores obtidos com sucesso!", Response = response};

                return result;
            }
            catch (Exception ex)
            {
                //TODO Logar erro
                return new SupplierResponse { Message =$"Erro: {ex.Message}"};
            }
           
        }

        public async Task<SupplierResponse> GetSupplierById(int id)
        {
            try
            {
                var supplier = await _supplierRepository.GetSupplier(id);
                var response = new List<SupplierTypeDTO> { _mapper.Map<SupplierTypeDTO>(supplier) };

                return new SupplierResponse { Message = "Forncedor obtido com sucesso!", Response = response };
            }
            catch (Exception ex)
            {
                //TODO Logar erro
                return new SupplierResponse { Message = $"Erro: {ex.Message}" };
            }
        }

        public async Task<SupplierResponse> InsertSupplier(SupplierTypeDTO supplier)
        {
            try
            {
                var newSupplier = _mapper.Map<SupplierType>(supplier);
                var result =  await _supplierRepository.InsertSupplier(newSupplier);
                var response = new List<SupplierTypeDTO> { _mapper.Map<SupplierTypeDTO>(result) };

                return new SupplierResponse { Message = "Fornecedor obtido com sucesso", Response = response };
            }
            catch (Exception ex)
            {
                //TODO Logar erro
                return new SupplierResponse { Message = $"Erro: {ex.Message}" };
            }
        }

        public async Task<SupplierResponse> UpdateSupplier(SupplierTypeDTO newSupplier)
        {
            try 
            {
                var supplierToUpdate = _mapper.Map<SupplierType>(newSupplier);
                var result = await _supplierRepository.UpdateSupplier(supplierToUpdate);
                var response = new List<SupplierTypeDTO> { _mapper.Map<SupplierTypeDTO>(result) };

                return new SupplierResponse { Message = "Atualizado com Sucesso!", Response = response };
            }
            catch (Exception ex)
            {
                //TODO Logar erro
                return new SupplierResponse { Message = $"Erro: {ex.Message}" };
            }
        }
    }
}
