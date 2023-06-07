using AutoMapper;
using FluentAssertions;
using Moq;
using Supplier.Domain.DTOs;
using Supplier.Domain.Models;
using Supplier.Infra.Interfaces;
using Supplier.Service.Services;

namespace Supplier.UnitTests.Service
{
    public class ServiceTests
    {
        private readonly SupplierService _supplierService;
        private readonly Mock<ISupplierRepository> _supplierRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public ServiceTests()
        {
            _supplierRepositoryMock = new Mock<ISupplierRepository>();
            _mapperMock = new Mock<IMapper>();
            _supplierService = new SupplierService(_supplierRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GivenACall_WhenGettingAllSuppliers_ThenReturnAListAsync()
        {
            //Arrage
            var mockReturn = new List<SupplierType>() { new SupplierType { Id = 1 } }.ToList();
            var expectedResponse = new List<SupplierTypeDTO>().AsEnumerable();
            _supplierRepositoryMock.Setup(p => p.GetAllSuppliers()).ReturnsAsync(mockReturn.AsEnumerable<SupplierType>);

            //Act
            var response = await _supplierService.GetAllSuppliers();

            //Assert
            response.Should().BeAssignableTo<IEnumerable<SupplierTypeDTO>>();
            response.Response.Should().ContainInOrder(expectedResponse);
        }

        [Fact]
        public void GivenARequest_WhenGettingAllSuppliersEmpty_ThenReturnAListEmpty()
        {
            //Arrage
            _supplierRepositoryMock.Setup(p => p.GetAllSuppliers()).ReturnsAsync(new List<SupplierType>());

            //Act
            var response = _supplierService.GetAllSuppliers().Result.Response;


            //Assert
            response.Should().HaveCount(0);
            response.Should().BeEmpty();
        }

        [Fact]
        public async Task GivenARequest_WhenGetASupplierId_ThenReturnASupplierAsync()
        {
            // Arrange
            int supplierId = 1;
            var mockSupplier = new SupplierType { Id = supplierId, FantasyName = "Supplier A" };
            var expectedResponse = new SupplierTypeDTO { Id = supplierId, FantasyName = "Supplier A" };

            _supplierRepositoryMock.Setup(repo => repo.GetSupplier(supplierId)).ReturnsAsync(mockSupplier);
            _mapperMock.Setup(mapper => mapper.Map<SupplierTypeDTO>(mockSupplier)).Returns(expectedResponse);

            // Act
            var result = await _supplierService.GetSupplierById(supplierId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResponse);
        }


        [Fact]
        public async Task GivenARequest_WhenAddASupplier_ThenReturnASupplierDTOAsync()
        {
            // Arrange
            var supplierDto = new SupplierTypeDTO { Id = 1, FantasyName = "Supplier A" };
            var newSupplier = new SupplierType { Id = 1, FantasyName = "Supplier A" };
            var insertedSupplier = new SupplierType { Id = 1, FantasyName = "Supplier A" };
            var expectedResponse = new SupplierTypeDTO { Id = 1, FantasyName = "Supplier A" };

            _mapperMock.Setup(mapper => mapper.Map<SupplierType>(supplierDto)).Returns(newSupplier);
            _supplierRepositoryMock.Setup(repo => repo.InsertSupplier(newSupplier)).ReturnsAsync(insertedSupplier);
            _mapperMock.Setup(mapper => mapper.Map<SupplierTypeDTO>(It.IsAny<SupplierType>())).Returns(expectedResponse);

            // Act
            var result = await _supplierService.InsertSupplier(supplierDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResponse);
        }

       
        [Fact]
        public async Task GiveASupplier_WhenValidSupplier_ReturnsUpdatedSupplier()
        {
            // Arrange
            var newSupplier = new SupplierTypeDTO { Id = 1, FantasyName = "Supplier A" };
            var mappedSupplier = new SupplierType { Id = 1, FantasyName = "Supplier A" };
            var insertedSupplier = new SupplierType { Id = 1, FantasyName = "Supplier B" };
            var expectedResponse = new SupplierTypeDTO { Id = 1, FantasyName = "Supplier A" };

            _mapperMock.Setup(m => m.Map<SupplierType>(newSupplier)).Returns(mappedSupplier);
            _supplierRepositoryMock.Setup(r => r.InsertSupplier(mappedSupplier)).ReturnsAsync(insertedSupplier);
            _mapperMock.Setup(m => m.Map<SupplierTypeDTO>(It.IsAny<SupplierType>())).Returns(expectedResponse);


            // Act
            var result = await _supplierService.UpdateSupplier(newSupplier);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void GivenARequest_WhenUDeleteASupplier_ThenReturnASupplier()
        {
            //Arrage
            _supplierRepositoryMock.Setup(p => p.DeleteSupplier(It.IsAny<int>())).ReturnsAsync(true);

            //Act
            var response = _supplierService.DeleteSupplier(1);


            //Assert
            response.Should().NotBeNull();
            response.Result.Should().BeTrue();
        }
    }
}
