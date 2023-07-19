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
        var body = JsonContent.Create(new TrancaViewModel
        {
            Localizacao = "",
            AnoDeFabricacao = "",
            Modelo = "",
            Status = "",
            Numero = 0
        });

        var response = await client.PostAsync(equipamentoAPI + "/tranca", body);
        response.EnsureSuccessStatusCode();
        var tranquinha = await response.Content.ReadFromJsonAsync<TrancaViewModel>();

        var responseTranca = await client.GetAsync(equipamentoAPI + "/tranca/" + tranquinha?.Id);
        responseTranca.EnsureSuccessStatusCode();
        var tranca = await responseTranca.Content.ReadFromJsonAsync<TrancaViewModel>();

        Assert.Equal(tranquinha, tranca);
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
    }
}