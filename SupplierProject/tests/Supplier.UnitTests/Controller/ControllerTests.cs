using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Supplier.Api.Controllers;
using Supplier.Domain.DTOs;
using Supplier.Domain.Models;
using Supplier.Domain.Responses;
using Supplier.Service.Interfaces;

namespace Supplier.UnitTests.Controller;

public class ControllerTests
{
    [Fact]
    public void GivenARequest_WhenGettingAListOfSuppliers_ThenReturnAList()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.GetAllSuppliers()).ReturnsAsync(new SupplierResponse { Message = "Teste", Response = new List<SupplierTypeDTO> { new SupplierTypeDTO { Id = 1} } });
        var controller = new SupplierController(mockService.Object);
        var expected = new List<SupplierType> {
            new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" } 
        };

        //Act
        var response = controller.GetAll();

        //Assert
        response.Result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public void GivenARequest_WhenGettingAListOfSuppliersEmpty_ThenReturnAListEmpty()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.GetAllSuppliers()).ReturnsAsync(new SupplierResponse { Message = "Erro" });
        var controller = new SupplierController(mockService.Object);

        //Act
        var response = controller.GetAll();


        //Assert
        var OKResult = response.Result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public void GivenARequest_WhenGetSupplierById_ThenReturnASupplier()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.GetSupplierById(It.IsAny<int>())).ReturnsAsync(new SupplierResponse { Message = "Teste", Response = new List<SupplierTypeDTO> { new SupplierTypeDTO { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" } } });
        var controller = new SupplierController(mockService.Object);
        var expected = new SupplierResponse { Message = "Teste", Response = new List<SupplierTypeDTO> { new SupplierTypeDTO { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" } } };

        //Act
        var response = controller.GetById(1);

        //Assert
        response.Result.Should().BeOfType<OkObjectResult>();
    }


    [Fact]
    public void GivenARequest_WhenAddASupplier_ThenReturnOk()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.InsertSupplier(It.IsAny<SupplierTypeDTO>())).ReturnsAsync(new SupplierResponse { Message = "Teste", Response = new List<SupplierTypeDTO> { new SupplierTypeDTO { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" } } });
        var controller = new SupplierController(mockService.Object);
        var newSupplier = new SupplierTypeDTO
        {
            FantasyName = "Mc Donalds",
            Cnpj = "00000/000-85",
            Email = "mac@gmail.com",
            Telephone = "11985092041"
        };
        var expected = new SupplierResponse { Message = "Teste", Response = new List<SupplierTypeDTO> { new SupplierTypeDTO { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" } } };

        //Act
        var response = controller.InsertSupplier(newSupplier);

        //Assert
        response.Result.Should().BeOfType<CreatedResult>();
    }


    [Fact]
    public void GivenARequest_WhenUpdateASupplier_ThenReturnOk()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.UpdateSupplier(It.IsAny<SupplierTypeDTO>())).ReturnsAsync(new SupplierResponse { Message = "Teste", Response = new List<SupplierTypeDTO> { new SupplierTypeDTO { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" } } });
        var controller = new SupplierController(mockService.Object);
        var newSupplier = new SupplierTypeDTO { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };

        //Act
        var response = controller.UpdateSupplier(newSupplier);

        //Assert
        var OKResult = response.Result.Should().BeOfType<NoContentResult>().Subject;
    }

    [Fact]
    public void GivenARequest_WhenDeleteASupplier_ThenReturnOk()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.DeleteSupplier(It.IsAny<int>())).ReturnsAsync(true);
        var controller = new SupplierController(mockService.Object);
      

        //Act
        var response = controller.DeleteSupplier(1);

        //Assert
        var OKResult = response.Result.Should().BeOfType<NoContentResult>().Subject;
    }

    [Fact]
    public void GivenARequestWithIdWorng_WhenDeleteASupplier_ThenReturn400()
    {
        //Arrage
        var mockService = new Mock<ISupplierService>();
        mockService.Setup(p => p.DeleteSupplier(It.IsAny<int>())).ReturnsAsync(false);
        var controller = new SupplierController(mockService.Object);


        //Act
        var response = controller.DeleteSupplier(2);

        //Assert
        var OKResult = response.Result.Should().BeOfType<BadRequestResult>().Subject;
    }
}