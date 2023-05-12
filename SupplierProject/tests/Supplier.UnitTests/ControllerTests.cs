using Supplier.Api.Controllers;
using Supplier.Domain.Models;

namespace Supplier.UnitTests;

public class ControllerTests
{
    [Fact]
    public void GivenARequest_WhenGettingAListOfSuppliers_ThenReturnAList()
    {
        //Arrage
        var controller = new SupplierController();
        var expected = new List<SupplierType> { new SupplierType { Id = 1 } };

        //Act
        var response = controller.GetAll();

        //Assert
        Assert.NotNull(response);
        Assert.Equal(expected.Count(), response.Count());
    }
}