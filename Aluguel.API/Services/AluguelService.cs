using AutoMapper;
using Aluguel.API.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.ResponseCompression;
using System.Diagnostics;

namespace Aluguel.API.Services
{
    public interface IAluguelService
    {
        public Task<AluguelViewModel?> CreateAluguel(AluguelInsertViewModel aluguel);
        public AluguelViewModel GetAluguel(int id);
        public bool Contains(int id);
        public List<AluguelViewModel> GetAll();
        public AluguelViewModel? GetAluguelAtivo(int ciclistaId);
        public Task<AluguelViewModel?> Devolver(AluguelRetrieveViewModel aluguel);
    }

    public class AluguelService : IAluguelService
    {
        private static readonly Dictionary<int, AluguelViewModel> dict = new();
        private readonly ICiclistaService _CiclistaService;
        private readonly IEquipamentoService _EquipamentoService;

        private readonly HttpClient HttpClient = new();
        private const string equipamentoAddress = "https://pmequipamento.herokuapp.com";


        private const string externoAPI = "https://pmexterno.herokuapp.com";

        public AluguelService(ICiclistaService ciclistaService, IEquipamentoService equipamentoService)
        {
            _CiclistaService = ciclistaService;
            _EquipamentoService = equipamentoService;
        }

        public async Task<AluguelViewModel?> CreateAluguel(AluguelInsertViewModel aluguel)
        {
            if (_CiclistaService.Contains(aluguel.CiclistaId))
            {
                var ciclista = _CiclistaService.GetCiclista(aluguel.CiclistaId);
                if (ciclista.EmailConfirmado)
                {
                    if (GetAluguelAtivo(ciclista.Id) != null)
                    {
                        throw new Exception();
                    }
                    var responseTranca = await HttpClient.GetAsync(equipamentoAddress + "/tranca/" + aluguel.TrancaId);
                    responseTranca.EnsureSuccessStatusCode();
                    var tranca = await responseTranca.Content.ReadFromJsonAsync<TrancaViewModel>();
                    if (tranca.Bicicleta == null)
                    {
                        throw new Exception();
                    }

                    var body = JsonContent.Create(new CobrancaDto
                    {
                        Valor = 10,
                        Ciclista = aluguel.CiclistaId
                    });


                    var response = await HttpClient.PostAsync(externoAPI + "/cobranca", body);

                    response.EnsureSuccessStatusCode();

                    int bicicleta = tranca.Bicicleta.Id;
                    var bodyTranca = JsonContent.Create(bicicleta);
                    var destranca = await HttpClient.PostAsync(equipamentoAddress + "/tranca/" + aluguel.TrancaId + "/destrancar/", bodyTranca);
                    destranca.EnsureSuccessStatusCode();

                    var result = new AluguelViewModel()
                    {
                        CiclistaId = ciclista.Id,
                        Id = dict.Count,
                        TrancaInicio = tranca.Id,
                        BicicletaId = tranca.Bicicleta.Id
                    };
                    dict.Add(dict.Count, result);
                    return result;
                }
            }
            return null;
        }

        public AluguelViewModel? GetAluguelAtivo(int ciclistaId)
        {
            Dictionary<int, AluguelViewModel>.ValueCollection objects = dict.Values;
            foreach (var value in objects)
            {
                if (value.CiclistaId == ciclistaId && (value.TrancaFim == null && value.DataDevolucao == null))
                {
                    return value;
                }
            }
            return null;
        }

        public AluguelViewModel GetAluguel(int id)
        {
            return dict.ElementAt(id).Value;
        }

        public bool Contains(int id)
        {
            if (dict.ContainsKey(id))
            {
                return true;
            }
            return false;
        }

        public List<AluguelViewModel> GetAll()
        {
            List<AluguelViewModel> result = new();
            Dictionary<int, AluguelViewModel>.ValueCollection objects = dict.Values;
            foreach (var value in objects)
            {
                result.Add(value);
            }
            return result;
        }

        public async Task<AluguelViewModel?> Devolver(AluguelRetrieveViewModel aluguel)
        {
            Dictionary<int, AluguelViewModel>.ValueCollection objects = dict.Values;
            foreach (var value in objects)
            {
                if (value.BicicletaId == aluguel.BicicletaId && (value.TrancaFim == null && value.DataDevolucao == null))
                {
                    value.DataDevolucao = DateTime.Now;
                    value.TrancaFim = aluguel.TrancaId;

                    int bicicleta = value.BicicletaId.Value;
                    var bodyTranca = JsonContent.Create(bicicleta);
                    var tranca = await HttpClient.PostAsync(equipamentoAddress + "/tranca/" + aluguel.TrancaId + "/trancar/", bodyTranca);
                    tranca.EnsureSuccessStatusCode();

                    var time = (value.DataDevolucao.Value - value.DataAluguel).TotalNanoseconds;
                    if (time >= 2)
                    {
                        var body = JsonContent.Create(new CobrancaDto
                        {
                            Valor = 10,
                            Ciclista = value.CiclistaId.Value
                        });


                        var response = await HttpClient.PostAsync(externoAPI + "/cobranca", body);

                        response.EnsureSuccessStatusCode();
                    }
                    return value;
                }
            }
            return null;
        }

    }
}