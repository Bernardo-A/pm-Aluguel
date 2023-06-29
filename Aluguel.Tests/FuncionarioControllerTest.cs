using Aluguel.API.AutoMapperProfiles;
using Aluguel.API.Controllers;
using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Aluguel.Tests;

public class FuncionarioControllerTest
{
    private readonly Mock<ILogger<FuncionarioController>> _logger = new();

    [Fact]
    public void CreateOnSuccessReturnStatusCode200()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();
        mockFuncionarioService.Setup(service => service.CreateFuncionario(It.IsAny<FuncionarioInsertViewModel>())).Returns(new FuncionarioViewModel());

        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (OkObjectResult)sut.Create(new FuncionarioInsertViewModel());

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void CreateOnErrorReturnStatusCode400()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();

        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (BadRequestResult)sut.Create(new FuncionarioInsertViewModel());

        result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void GetOnSuccessReturnStatusCode200()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();
        mockFuncionarioService.Setup(service => service.Contains(It.IsAny<int>())).Returns(true);
        mockFuncionarioService.Setup(service => service.GetFuncionario(It.IsAny<int>())).Returns(new FuncionarioViewModel());

        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (OkObjectResult)sut.Get(0);

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void GetOnErrorReturnStatusCode404()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();
        mockFuncionarioService.Setup(service => service.Contains(It.IsAny<int>())).Returns(false);

        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (NotFoundResult)sut.Get(0);

        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public void EditOnSuccessReturnStatusCode200()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();
        mockFuncionarioService.Setup(service => service.Contains(It.IsAny<int>())).Returns(true);
        mockFuncionarioService.Setup(service => service.UpdateFuncionario((It.IsAny<FuncionarioEditViewModel>()), It.IsAny<int>())).Returns(new FuncionarioViewModel());

        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (OkObjectResult)sut.Get(0);

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void EditOnErrorReturnStatusCode404()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();
        mockFuncionarioService.Setup(service => service.Contains(It.IsAny<int>())).Returns(false);


        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (NotFoundResult)sut.Get(0);

        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public void DeleteOnSuccessReturnStatusCode200()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();
        mockFuncionarioService.Setup(service => service.Contains(It.IsAny<int>())).Returns(true);
        mockFuncionarioService.Setup(service => service.DeleteFuncionario(It.IsAny<int>())).Returns(new FuncionarioViewModel());

        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (OkObjectResult)sut.Delete(0);

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void DeleteOnErrorReturnStatusCode404()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();
        mockFuncionarioService.Setup(service => service.Contains(It.IsAny<int>())).Returns(false);


        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (NotFoundResult)sut.Delete(0);

        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public void GetAllOnSuccessReturnStatusCode200()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();
        mockFuncionarioService.Setup(service => service.IsEmpty()).Returns(false);
        mockFuncionarioService.Setup(service => service.GetAll());

        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (OkObjectResult)sut.GetAll();

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void GetAllOnErrorReturnStatusCode404()
    {
        var mockFuncionarioService = new Mock<IFuncionarioService>();
        mockFuncionarioService.Setup(service => service.IsEmpty()).Returns(true);

        var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

        var result = (NotFoundResult)sut.GetAll();

        result.StatusCode.Should().Be(404);
    }

}