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
    public async void CreateOnSuccessReturnStatusCode200()
    {
        var mockAluguelService = new Mock<IAluguelService>();
        mockAluguelService.Setup(service => service.CreateAluguel(It.IsAny<AluguelInsertViewModel>())).ReturnsAsync(new AluguelViewModel());

        var sut = new AluguelController(mockAluguelService.Object);

        var result = await sut.Create(new AluguelInsertViewModel()) as OkObjectResult;

        result?.StatusCode?.Should().Be(200);
    }

    [Fact]
    public async void CreateOnErrorReturnStatusCode400()
    {
        var mockAluguelService = new Mock<IAluguelService>();

        var sut = new AluguelController(mockAluguelService.Object);

        var result = await sut.Create(new AluguelInsertViewModel()) as BadRequestResult;

        result?.StatusCode.Should().Be(400);
    }

    [Fact]
    public async void RetrieveOnSuccessReturnsStatusCode200()
    {

        var mockAluguelService = new Mock<IAluguelService>();
        mockAluguelService.Setup(service => service.Devolver(It.IsAny<AluguelRetrieveViewModel>())).ReturnsAsync(new AluguelViewModel());

        var sut = new AluguelController(mockAluguelService.Object);

        var result = await sut.Retrieve(new AluguelRetrieveViewModel()) as OkObjectResult;

        result?.StatusCode?.Should().Be(200);
    }

    [Fact]
    public async void RetrieveOnErrorReturnsStatusCode404()
    {

        var mockAluguelService = new Mock<IAluguelService>();

        var sut = new AluguelController(mockAluguelService.Object);

        var result = await sut.Retrieve(new AluguelRetrieveViewModel()) as NotFoundResult;

        result?.StatusCode.Should().Be(404);
    }

}