using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
        mockService.Setup(p => p.GetAllSuppliers()).ReturnsAsync(new List<SupplierType> { new SupplierType { Id = 1 } });
        var controller = new SupplierController(mockService.Object);
        var expected = new List<SupplierType> {
            new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" } 
        };

        //Act
        var response = controller.GetAll();

        //Assert
        var OKResult = response.Result.Should().BeOfType<OkObjectResult>().Subject;
        var suppliers = OKResult.Value.Should().BeAssignableTo<IEnumerable<SupplierType>>().Subject;
        suppliers.Should().HaveCount(1);
    }

    [Fact]
    public void GivenARequest_WhenGettingAListOfSuppliersEmpty_ThenReturnAListEmpty()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.GetAllSuppliers()).ReturnsAsync(new List<SupplierType>());
        var controller = new SupplierController(mockService.Object);

        //Act
        var response = controller.GetAll();

        //Assert
        var OKResult = response.Result.Should().BeOfType<OkObjectResult>().Subject;
        var suppliers = OKResult.Value.Should().BeAssignableTo<IEnumerable<SupplierType>>().Subject;
        suppliers.Should().HaveCount(0);
    }

    [Fact]
    public void GivenARequest_WhenGetSupplierById_ThenReturnASupplier()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.GetSupplierById(It.IsAny<int>())).ReturnsAsync(new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" });
        var controller = new SupplierController(mockService.Object);
        var expected = new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };

        //Act
        var response = controller.GetById(1);

        //Assert
        var OKResult = response.Result.Should().BeOfType<OkObjectResult>().Subject;
        var supplier = OKResult.Value.Should().BeAssignableTo<SupplierType>().Subject;
        supplier.Should().BeEquivalentTo(expected);
    }


    [Fact]
    public void GivenARequest_WhenAddASupplier_ThenReturnOk()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.InsertSupplier(It.IsAny<SupplierType>())).ReturnsAsync(new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" });
        var controller = new SupplierController(mockService.Object);
        var expected = new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };

        //Act
        var response = controller.InsertSupplier(expected);

        //Assert
        var OKResult = response.Result.Should().BeOfType<CreatedResult>().Subject;
        var supplier = OKResult.Value.Should().BeAssignableTo<SupplierType>().Subject;
        supplier.Should().BeEquivalentTo(expected);
    }


    [Fact]
    public void GivenARequest_WhenUpdateASupplier_ThenReturnOk()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.UpdateSupplier(It.IsAny<SupplierType>())).ReturnsAsync(new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" });
        var controller = new SupplierController(mockService.Object);
        var newSupplier = new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };

        //Act
        var response = controller.UpdateSupplier(newSupplier);

        //Assert
        var OKResult = response.Result.Should().BeOfType<NoContentResult>().Subject;
    }
}