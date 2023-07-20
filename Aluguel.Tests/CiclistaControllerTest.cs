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

public class CiclistaControllerTest
{
    private readonly Mock<ILogger<CiclistaController>> _logger = new();
    private readonly Mock<IAluguelService> _aluguel = new();

    [Fact]
    public async void CreateOnSuccessReturnStatusCode200()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.CreateCiclista(It.IsAny<CiclistaInsertViewModel>())).ReturnsAsync(new CiclistaViewModel());

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = await sut.Create(new CiclistaInsertViewModel()) as OkObjectResult;

        result?.StatusCode.Should().Be(200);
    }

    [Fact]
    public async void CreateOnErrorReturnStatusCode400()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = await sut.Create(new CiclistaInsertViewModel()) as BadRequestResult;

        result?.StatusCode.Should().Be(400);
    }

    [Fact]
    public void GetOnSuccessReturnStatusCode200()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.Contains(It.IsAny<int>())).Returns(true);
        mockCiclistaService.Setup(service => service.GetCiclista(It.IsAny<int>())).Returns(new CiclistaViewModel());

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (OkObjectResult)sut.Get(0);

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void GetOnErrorReturnStatusCode404()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.Contains(It.IsAny<int>())).Returns(false);

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (NotFoundResult)sut.Get(0);

        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public void ActivateOnSuccessReturnStatusCode200()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.Contains(It.IsAny<int>())).Returns(true);
        mockCiclistaService.Setup(service => service.Activate(It.IsAny<int>())).Returns(new CiclistaViewModel());

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (OkObjectResult)sut.Get(0);

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void ActivateOnErrorReturnStatusCode404()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.Contains(It.IsAny<int>())).Returns(false);

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (NotFoundResult)sut.Get(0);

        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public void CheckAluguelOnSuccessTrueReturnStatusCode200()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.Contains(It.IsAny<int>())).Returns(true);
        mockAluguelService.Setup(service => service.GetAluguelAtivo(It.IsAny<int>())).Returns(new AluguelViewModel());

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (OkObjectResult)sut.CheckAluguel(0);

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void CheckAluguelOnErrorReturnStatusCode404()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.Contains(It.IsAny<int>())).Returns(false);


        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (NotFoundResult)sut.CheckAluguel(0);

        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public void GetBicicletaOnSuccessTrueReturnStatusCode200()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.Contains(It.IsAny<int>())).Returns(true);
        mockAluguelService.Setup(service => service.GetAluguelAtivo(It.IsAny<int>())).Returns(new AluguelViewModel());

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (OkObjectResult)sut.GetBicicleta(0);

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void GetBicicletaOnErrorReturnStatusCode404()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.Contains(It.IsAny<int>())).Returns(false);

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (NotFoundResult)sut.GetBicicleta(0);

        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public void CheckEmailOnSuccessTrueReturnStatusCode200()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.IsEmailRegistered(It.IsAny<string>())).Returns(true);

        var mockLogger = new Mock<ILogger<CiclistaController>>();

        var sut = new CiclistaController(_logger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (OkObjectResult)sut.CheckEmail("string");

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void CheckEmailOnErrorReturnStatusCode404()
    {
        var mockCiclistaService = new Mock<ICiclistaService>();
        var mockAluguelService = new Mock<IAluguelService>();
        mockCiclistaService.Setup(service => service.IsEmailRegistered(It.IsAny<string>())).Returns(false);

        var mockLogger = new Mock<ILogger<CiclistaController>>();

        var sut = new CiclistaController(mockLogger.Object, mockCiclistaService.Object, _aluguel.Object);

        var result = (NotFoundResult)sut.CheckEmail("string");

        result.StatusCode.Should().Be(404);
    }

}