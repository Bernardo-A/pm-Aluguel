using AutoMapper;
using Aluguel.API.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Aluguel.API.Services
{
    public interface IAluguelService
    {
        public Task CreateAluguel(AluguelInsertViewModel aluguel);
        public AluguelViewModel GetAluguel(int id);
        public bool Contains(int id);
        public List<AluguelViewModel> GetAll();
        public AluguelViewModel? GetAluguelAtivo(int ciclistaId);
        public AluguelViewModel? Devolver(AluguelRetrieveViewModel aluguel);
    }

    public class AluguelService : IAluguelService
    {
        private static readonly Dictionary<int, AluguelViewModel> dict = new();
        private readonly ICiclistaService _CiclistaService;
        private readonly IEquipamentoService _EquipamentoService;

        private readonly HttpClient HttpClient = new();

        private const string externoAPI = "https://pmexterno.herokuapp.com";

        public AluguelService(ICiclistaService ciclistaService, IEquipamentoService equipamentoService)
        {
            _CiclistaService = ciclistaService;
            _EquipamentoService = equipamentoService;
        }

        public async Task CreateAluguel(AluguelInsertViewModel aluguel)
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

                    var requestBody = JsonConvert.SerializeObject(new CobrancaDto
                    {
                        Valor = 10,
                        Ciclista = aluguel.CiclistaId
                    });

                    var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                    var response = await HttpClient.PostAsync(externoAPI + "/cobranca", content);

                    response.EnsureSuccessStatusCode();

                    var tranca = _EquipamentoService.GetTranca(aluguel.TrancaId);
                    if (tranca.BicicletaId == null)
                    {
                        throw new Exception();
                    }
                    var result = new AluguelViewModel()
                    {
                        CiclistaId = ciclista.Id,
                        Id = dict.Count,
                        TrancaInicio = tranca.Id,
                        BicicletaId = tranca.BicicletaId
                    };
                    dict.Add(dict.Count, result);
                    return;
                }
            }
            throw new Exception();
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

        public AluguelViewModel? Devolver(AluguelRetrieveViewModel aluguel)
        {
            Dictionary<int, AluguelViewModel>.ValueCollection objects = dict.Values;
            foreach (var value in objects)
            {
                if (value.BicicletaId == aluguel.BicicletaId && (value.TrancaFim == null && value.DataDevolucao == null))
                {
                    value.DataDevolucao = DateTime.Now;
                    value.TrancaFim = aluguel.TrancaId;
                    return value;
                }
            }
            return null;
        }

    }
}