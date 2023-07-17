using AutoMapper;
using Aluguel.API.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.API.Services
{
    public interface IEquipamentoService
    {
        public Task<TrancaViewModel> GetTranca(int id);
    }

    public class EquipamentoService : IEquipamentoService
    {     
        public async Task<TrancaViewModel> GetTranca(int id)
        {
            return new TrancaViewModel
            {
                Id = 0,
                BicicletaId = 1
            };
            
        }
    }
}