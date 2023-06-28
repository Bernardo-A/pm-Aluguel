using Aluguel.API.AutoMapperProfiles;
using Aluguel.API.Controllers;
using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using Aluguel.Tests.MockData;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Aluguel.Tests;

public class CiclistaControllerTest
{
    private readonly Mock<ILogger<CiclistaController>> _logger = new();
    [Fact]
    public void CreateOnSuccessReturnStatusCode200()
    {
        var myProfile = new CiclistaAutoMapperProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        var mapper = new Mapper(configuration);

        var alugueMockService = new Mock<IAluguelService>();
        var ciclistaMockService = new Mock<ICiclistaService>();
        ciclistaMockService.Setup(service => service.CreateCiclista(CiclistaMockData.GetCiclistaMockData())).Returns(new CiclistaViewModel());

        var sut = new CiclistaController(_logger.Object, ciclistaMockService.Object, alugueMockService.Object);

        var result = (OkObjectResult)sut.Create(CiclistaMockData.GetCiclistaMockData());

        result.StatusCode.Should().Be(200);
    }

    //[Fact]
    //public void EditOnSuccessReturnStatusCode200()
    //{
    //    var myProfile = new CiclistaAutoMapperProfile();
    //    var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
    //    var mapper = new Mapper(configuration);

    //    var mockLogger = new Mock<ILogger<CiclistaController>>();
    //    var mockService = new Mock<ICiclistaService>();

    //    mockService.Setup(service => service.GetCiclista()).Returns(CiclistaMockData.GetCiclistaViewModelMockData());

    //    var sut = new CiclistaController(mockLogger.Object, mapper, mockService.Object);

    //    var result = (OkObjectResult)sut.Edit(CiclistaMockData.GetCiclistaEditMockData(), 0);

    //    result.StatusCode.Should().Be(200);
    //}

    //[Fact]
    //public void EnableciclistaOnSuccessReturnStatusCode200()
    //{
    //    var mockMapper = new Mock<IMapper>();
    //    var mockLogger = new Mock<ILogger<CiclistaController>>();
    //    var mockService = new Mock<ICiclistaService>();
    //    mockService.Setup(service => service.GetCiclista()).Returns(new CiclistaViewModel());

    //    var sut = new CiclistaController(mockLogger.Object, mockMapper.Object, mockService.Object);

    //    var result = (OkObjectResult)sut.EnableCiclista("000", 0);

    //    result.StatusCode.Should().Be(200);
    //}

    //[Fact]
    //public void EditCartaoOnSucessReturnsStatusCode200()
    //{
    //    var myProfile = new CiclistaAutoMapperProfile();
    //    var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
    //    var mapper = new Mapper(configuration);

    //    var mockLogger = new Mock<ILogger<CiclistaController>>();
    //    var mockService = new Mock<ICiclistaService>();

    //    mockService.Setup(service => service.GetCiclista()).Returns(CiclistaMockData.GetCiclistaViewModelMockData());

    //    var sut = new CiclistaController(mockLogger.Object, mapper, mockService.Object);

    //    var result = (OkObjectResult)sut.EditCartao(CiclistaMockData.GetMeiodeDePagamentoMockData(), 0);

    //    result.StatusCode.Should().Be(200);

    //}

    //[Fact]
    //public void CiclistaServiceGetCiclistaReturnsCiclistaViewModel()
    //{
    //    var service = new CiclistaService();

    //    var sut = service.GetCiclista();

    //    Assert.IsType<CiclistaViewModel>(sut);
    //}

}