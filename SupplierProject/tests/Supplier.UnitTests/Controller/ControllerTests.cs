using Moq;
using Supplier.Api.Controllers;
using Supplier.Domain.Models;
using Supplier.Service.Interfaces;

namespace Supplier.UnitTests.Controller;

public class ControllerTests
{
    [Fact]
    public void GivenARequest_WhenGettingAListOfSuppliers_ThenReturnAList()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.GetAllSuppliers()).Returns(new List<SupplierType> { new SupplierType { Id = 1 } });
        var controller = new SupplierController(mockService.Object);
        var expected = new List<SupplierType> { new SupplierType { Id = 1 } };

        //Act
        var response = controller.GetAll();

        //Assert
        Assert.NotNull(response);
        Assert.Equal(expected.Count(), response.Count());
    }
}