using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
            var response = service.GetAllSuppliers();

            //Assert
            var OKResult = response.Should().BeOfType<Task<IEnumerable<SupplierType>>>().Subject;
            var supplier = OKResult.Result.Should().HaveCount(mockReturn.Count);
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

        [Fact]
        public void GivenARequest_WhenGetASupplierId_ThenReturnASupplier()
        {
            //Arrage
            var mockRepository = new Mock<ISupplierRepository>();
            var mockReturn = new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };
            mockRepository.Setup(p => p.GetSupplier(It.IsAny<int>())).ReturnsAsync(mockReturn);
            var service = new SupplierService(mockRepository.Object);

            //Act
            var response = service.GetSupplierById(1);


            //Assert
            response.Should().NotBeNull();
            var result = response.Result.Should().BeOfType<SupplierType>().Subject;
            var supplier = result.Id.Should().Be(mockReturn.Id);
        }
    }
}
