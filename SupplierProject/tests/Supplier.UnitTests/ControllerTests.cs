using Supplier.Api.Controllers;

namespace Supplier.UnitTests;

public class ControllerTests
{
    [Fact]
    public void When_GivenRequest_ReturnHelloWorld()
    {
        //Arrage
        var controller = new SupplierController();
        var expected = "Hello World!";
        //Act
        var response = controller.HelloWorld();

        //Assert
        Assert.NotNull(response);
        Assert.Equal(expected, response);

    }
}