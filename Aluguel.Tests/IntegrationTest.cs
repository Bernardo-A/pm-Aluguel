using Aluguel.API.AutoMapperProfiles;
using Aluguel.API.Controllers;
using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System.Net.Http.Json;
using Xunit;

namespace Aluguel.Tests;

public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private const string equipamentoAPI = "https://pmequipamento.herokuapp.com";
    private const string externoAPI = "https://pmexterno.herokuapp.com";
    private readonly WebApplicationFactory<Program> _factory;

    public IntegrationTest(WebApplicationFactory<Program> factory)
    {  
        _factory = factory;
    }

    [Fact]
    public async Task GetTrancaReturnTranca()
    {
        var client = _factory.CreateClient();

        var responseTranca = await client.GetAsync(equipamentoAPI + "/tranca/" + 0);
        responseTranca.EnsureSuccessStatusCode();

        Assert.True(responseTranca.IsSuccessStatusCode);
    }

    [Fact]
    public async Task PostCobrancaOnSuccessReturnsCobranca()
    {
        var client = _factory.CreateClient();

        var body = JsonContent.Create(new CobrancaDto
        {
            Valor = 10,
            Ciclista = It.IsAny<int>(),
        });


        var response = await client.PostAsync(externoAPI + "/cobranca", body);
        response.EnsureSuccessStatusCode();
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task PostEmailOnSuccessReturns200()
    {
        var client = _factory.CreateClient();

        var body = JsonContent.Create(new EmailDto
        {
            Mensagem = "testando",
            Assunto = "teste",
            Email = "bernardo.agrelos@edu.unirio.br"
        });


        var response = await client.PostAsync(externoAPI + "/enviarEmail", body);

        response.EnsureSuccessStatusCode();
        Assert.True(response.IsSuccessStatusCode);
    }
}