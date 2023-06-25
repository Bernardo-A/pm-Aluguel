using AutoMapper;
using Aluguel.API.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.API.Services
{
    public interface IAluguelService
    {
        public AluguelViewModel CreateAluguel(AluguelInsertViewModel Aluguel);
        public AluguelViewModel GetAluguel(int id);
        public bool Contains(int id);
        public List<AluguelViewModel> GetAll();
        public bool HasAluguelAtivo(int ciclistaId);

        //public AluguelViewModel DeleteAluguel(int id);
    }

    public class AluguelService : IAluguelService
    {
        private static readonly Dictionary<int, AluguelViewModel> dict = new();

        private readonly IMapper _mapper;

        public AluguelService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AluguelViewModel CreateAluguel(AluguelInsertViewModel solicitacao)
        {
            var aluguel = new AluguelViewModel
            {
                CiclistaId = solicitacao.CiclistaId,
                Id = dict.Count,
                TrancaInicio = solicitacao.TrancaId
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
                    if (value.TrancaFim != null && value.DataDevolucao != null)
                    {
                        return true;
                    }
                }
            }
            return false;
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