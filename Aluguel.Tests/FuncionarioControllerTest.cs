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

    //[Fact]
    //public void GetOnSuccessReturnStatusCode200()
    //{
    //    var mockFuncionarioService = new Mock<IFuncionarioService>();
    //    mockFuncionarioService.Setup(service => service.Contains(It.IsAny<int>())).Returns(true);

    //    var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

    //    var result = (OkObjectResult)sut.Get(int);

    //    result.StatusCode.Should().Be(200);
    //}

    //[Fact]
    //public void GetOnErrorReturnStatusCode404()
    //{
    //    var mockFuncionarioService = new Mock<IFuncionarioService>();

    //    var sut = new FuncionarioController(_logger.Object, mockFuncionarioService.Object);

    //    var result = (BadRequestResult)sut.Create(new FuncionarioInsertViewModel());

    //    result.StatusCode.Should().Be(404);
    //}

    //[Fact]
    //public void RetrieveOnSuccessReturnsStatusCode200()
    //{

    //    var mockFuncionarioService = new Mock<IFuncionarioService>();
    //    mockFuncionarioService.Setup(service => service.Devolver(It.IsAny<FuncionarioRetrieveViewModel>())).Returns(new FuncionarioViewModel());

    //    var sut = new FuncionarioController(mockFuncionarioService.Object);

    //    var result = (OkObjectResult)sut.Retrieve(new FuncionarioRetrieveViewModel());

    //    result.StatusCode.Should().Be(200);
    //}

    //[Fact]
    //public void RetrieveOnErrorReturnsStatusCode404()
    //{

    //    var mockFuncionarioService = new Mock<IFuncionarioService>();

    //    var sut = new FuncionarioController(mockFuncionarioService.Object);

    //    var result = (NotFoundResult)sut.Retrieve(new FuncionarioRetrieveViewModel());

    //    result.StatusCode.Should().Be(404);
    //}

}




//using Aluguel.API.AutoMapperProfiles;
//using Aluguel.API.Controllers;
//using Aluguel.API.Services;
//using Aluguel.API.ViewModels;
//using Aluguel.Tests.MockData;
//using AutoMapper;
//using FluentAssertions;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Moq;
//using Xunit;

//namespace Aluguel.Tests;

//public class FuncionarioControllerTest
//{
//    [Fact]
//    public void CreateOnSuccessReturnStatusCode200()
//    {
//        var mockMapper = new Mock<IMapper>();
//        var mockLogger = new Mock<ILogger<FuncionarioController>>();
//        var mockService = new Mock<IFuncionarioService>();

//        var sut = new FuncionarioController(mockLogger.Object, mockMapper.Object, mockService.Object);

//        var result = (OkObjectResult)sut.Create(FuncionarioMockData.GetFuncionarioInsertMockData());

//        result.StatusCode.Should().Be(200);
//    }

//    [Fact]
//    public void DeleteOnSuccessReturnStatusCode200()
//    {
//        var mockMapper = new Mock<IMapper>();
//        var mockLogger = new Mock<ILogger<FuncionarioController>>();
//        var mockService = new Mock<IFuncionarioService>();

//        mockService.Setup(service => service.GetFuncionario()).Returns(FuncionarioMockData.GetFuncionarioViewModelMockData());

//        var sut = new FuncionarioController(mockLogger.Object, mockMapper.Object, mockService.Object);

//        var result = (OkObjectResult)sut.Delete(0);

//        result.StatusCode.Should().Be(200);
//    }

//    [Fact]
//    public void EditOnSuccessReturnsStatusCode200()
//    {
//        var mockLogger = new Mock<ILogger<FuncionarioController>>();
//        var mockService = new Mock<IFuncionarioService>();

//        var myProfile = new FuncionarioAutoMapperProfile();
//        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
//        var mapper = new Mapper(configuration);

//        mockService.Setup(service => service.GetFuncionario()).Returns(FuncionarioMockData.GetFuncionarioViewModelMockData());

//        var sut = new FuncionarioController(mockLogger.Object, mapper, mockService.Object);

//        var result = (OkObjectResult)sut.Edit(FuncionarioMockData.GetFuncionarioEditViewModelMockData(), 0);

//        result.StatusCode.Should().Be(200);
//    }

//    [Fact]
//    public void FuncionarioServiceGetFuncionarioReturnsFuncionarioViewModel()
//    {
//        var service = new FuncionarioService();

//        var sut = new FuncionarioService().GetFuncionario();

//        Assert.IsType<FuncionarioViewModel>(sut);
//    }
//}