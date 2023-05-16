using FluentAssertions;
using Moq;
using Supplier.Api.Controllers;
using Supplier.Domain.Models;
using Supplier.Infra.Interfaces;
using Supplier.Service.Interfaces;
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
            mockRepository.Setup(p => p.GetAllSuppliers()).Returns(mockReturn.AsEnumerable<SupplierType>);
            var service = new SupplierService();

            //Act
            var response = service.GetAllSuppliers();


            //Assert
            response.Should().NotBeNullOrEmpty();
        }
    }
}
