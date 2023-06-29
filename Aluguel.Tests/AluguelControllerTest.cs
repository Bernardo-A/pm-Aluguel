using Aluguel.API.AutoMapperProfiles;
using Aluguel.API.Controllers;
using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Aluguel.Tests;

public class AluguelControllerTest
{
    private readonly Mock<ILogger<AluguelController>> _logger = new();

    [Fact]
    public void CreateOnSuccessReturnStatusCode200()
    {
        var mockAluguelService = new Mock<IAluguelService>();
        mockAluguelService.Setup(service => service.CreateAluguel(It.IsAny<AluguelInsertViewModel>())).Returns(new AluguelViewModel());

        var sut = new AluguelController(mockAluguelService.Object);

        var result = (OkObjectResult)sut.Create(new AluguelInsertViewModel());

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void CreateOnErrorReturnStatusCode400()
    {
        var mockAluguelService = new Mock<IAluguelService>();

        var sut = new AluguelController(mockAluguelService.Object);

        var result = (BadRequestResult)sut.Create(new AluguelInsertViewModel());

        result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void RetrieveOnSuccessReturnsStatusCode200()
    {

        var mockAluguelService = new Mock<IAluguelService>();
        mockAluguelService.Setup(service => service.Devolver(It.IsAny<AluguelRetrieveViewModel>())).Returns(new AluguelViewModel());

        var sut = new AluguelController(mockAluguelService.Object);

        var result = (OkObjectResult)sut.Retrieve(new AluguelRetrieveViewModel());

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void RetrieveOnErrorReturnsStatusCode404()
    {

        var mockAluguelService = new Mock<IAluguelService>();

        var sut = new AluguelController(mockAluguelService.Object);

        var result = (NotFoundResult)sut.Retrieve(new AluguelRetrieveViewModel());

        result.StatusCode.Should().Be(404);
    }

}