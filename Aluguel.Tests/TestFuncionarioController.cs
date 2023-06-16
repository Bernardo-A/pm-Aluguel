using Aluguel.API.Controllers;
using Aluguel.API.ViewModels;
using Aluguel.Tests.MockData;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Aluguel.Tests;

public class TestFuncionarioController
{
    [Fact]
    public void CreateOnSuccessReturnStatusCode200()
    {
        var mockMapper = new Mock<IMapper>();
        var mockLogger = new Mock<ILogger<FuncionarioController>>();

        var sut = new FuncionarioController(mockLogger.Object, mockMapper.Object);

        var result = (OkObjectResult)sut.Create(FuncionarioMockData.GetFuncionarioMockData());

        result.StatusCode.Should().Be(200);
    }

    //[Fact]
    //public async Task Creat_OnSucess_InvokeMapperAndLogger()
    //{
    //    var mockMapper = new Mock<IMapper>();

    //    var sut = new CiclistaController(_mapper)

    //    var result = (OkObjectResult)await sut.Create
    //}
}