using AutoMapper;
using Aluguel.API.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.API.Services
{
    public interface IAluguelService
    {
        public AluguelViewModel CreateAluguel(CiclistaViewModel ciclista, TrancaViewModel tranca);
        public AluguelViewModel GetAluguel(int id);
        public bool Contains(int id);
        public List<AluguelViewModel> GetAll();
        public bool HasAluguelAtivo(int ciclistaId);
        public AluguelViewModel GetAluguelAtivo(int ciclistaId);

        //public AluguelViewModel DeleteAluguel(int id);
    }

    public class AluguelService : IAluguelService
    {
        private static readonly Dictionary<int, AluguelViewModel> dict = new();

        private readonly IMapper _mapper;
        private readonly ICiclistaService _CiclistaService;

        public AluguelService(IMapper mapper, ICiclistaService CiclistaService)
        {
            _mapper = mapper;
            _CiclistaService = CiclistaService;
        }

        public AluguelViewModel CreateAluguel(CiclistaViewModel ciclista, TrancaViewModel tranca)
        {
            var aluguel = new AluguelViewModel
            {
                CiclistaId = ciclista.Id,
                Id = dict.Count,
                TrancaInicio = tranca.Id,
                BicicletaId = tranca.BicicletaId
            };
            dict.Add(dict.Count, aluguel);
            return aluguel;
        }

        public bool HasAluguelAtivo (int ciclistaId)
        {
            Dictionary<int, AluguelViewModel>.ValueCollection objects = dict.Values;
            foreach (var value in objects)
            {
                if (value.CiclistaId == ciclistaId)
                {
                    if (value.TrancaFim == null && value.DataDevolucao == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public AluguelViewModel GetAluguelAtivo(int ciclistaId)
        {
            Dictionary<int, AluguelViewModel>.ValueCollection objects = dict.Values;
            foreach (var value in objects)
            {
                if (value.CiclistaId == ciclistaId)
                {
                    if (value.TrancaFim == null && value.DataDevolucao == null)
                    {
                        return value;
                    }
                }
            }
            return new AluguelViewModel();
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

        //public AluguelViewModel DeleteAluguel(int id)
        //{
        //    dict[id].Status = "Excluida";
        //    return dict.ElementAt(id).Value;
        //}

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

    }
}