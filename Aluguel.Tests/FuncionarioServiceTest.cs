using Aluguel.API.AutoMapperProfiles;
using Aluguel.API.Controllers;
using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Aluguel.Tests;

public class FuncionarioServiceTest
{
    private readonly Mock<IMapper> _mapper = new();

    [Fact]
    public void CreateOnSuccessReturnStatusCode200()
    {
        var sut = new FuncionarioService(_mapper.Object);

        var result = sut.CreateFuncionario(new FuncionarioInsertViewModel());
        Assert.Equal(typeof(FuncionarioInsertViewModel), result.GetType());
    }

    [Fact]
    public void UpdateOnSuccessReturnStatusCode200()
    {
        var sut = new FuncionarioService(_mapper.Object);

        var result = sut.UpdateFuncionario(new FuncionarioEditViewModel(), 0);
        Assert.Equal(typeof(FuncionarioEditViewModel), result.GetType());
    }

    [Fact]
    public void GetOnSuccessReturnStatusCode200()
    {
        var sut = new FuncionarioService(_mapper.Object);

        var result = sut.GetFuncionario(0);
        Assert.Equal(typeof(FuncionarioViewModel), result.GetType());
    }

    [Fact]
    public void DeleteOnSuccessReturnStatusCode200()
    {
        var sut = new FuncionarioService(_mapper.Object);

        var result = sut.DeleteFuncionario(0);
        Assert.Equal(typeof(FuncionarioEditViewModel), result.GetType());
    }

}