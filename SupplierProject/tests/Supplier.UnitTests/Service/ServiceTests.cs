using FluentAssertions;
using Moq;
using Supplier.Domain.Models;
using Supplier.Infra.Interfaces;
using Supplier.Service.Services;

namespace Supplier.UnitTests.Service
{
    public class ServiceTests
    {
        [Fact]
        public void GivenACall_WhenGettingAllSuppliers_ThenReturnAList()
        {
            //Arrage
            var mockRepository = new Mock<ISupplierRepository>();
            var mockReturn = new List<SupplierType>() { new SupplierType { Id = 1 } }.ToList();
            mockRepository.Setup(p => p.GetAllSuppliers()).ReturnsAsync(mockReturn.AsEnumerable<SupplierType>);
            var service = new SupplierService(mockRepository.Object);

            //Act
            var response = service.GetAllSuppliers().Result.ToList();


            //Assert
            response.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GivenARequest_WhenGettingAllSuppliersEmpty_ThenReturnAListEmpty()
        {
            //Arrage
            var mockRepository = new Mock<ISupplierRepository>();
            mockRepository.Setup(p => p.GetAllSuppliers()).ReturnsAsync(new List<SupplierType>());
            var service = new SupplierService(mockRepository.Object);

            //Act
            var response = service.GetAllSuppliers().Result.ToList();


            //Assert
            response.Should().HaveCount(0);
            response.Should().BeEmpty();
        }
    }
}
