using AutoMapper;
using Aluguel.API.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Aluguel.API.Services
{
    public interface ICiclistaService
    {
        public Task<CiclistaViewModel> CreateCiclista(CiclistaInsertViewModel Ciclista);
        public CiclistaViewModel GetCiclista(int id);
        public CiclistaViewModel UpdateCiclista(CiclistaEditViewModel ciclistaNovo, int id);
        public bool Contains(int id);
        public List<CiclistaViewModel> GetAll();
        public CiclistaViewModel Activate(int id);
        public bool IsEmailRegistered(string email);
        public CiclistaViewModel UpdateCartao(MeioDePagamentoViewModel cartaoNovo, int id);
    }

    public class CiclistaService : ICiclistaService
    {
        private static readonly Dictionary<int, CiclistaViewModel> dict = new();

        private readonly IMapper _mapper;

        private readonly HttpClient HttpClient = new();

        private const string externoAPI = "https://pmexterno.herokuapp.com";

        public CiclistaService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CiclistaViewModel> CreateCiclista(CiclistaInsertViewModel Ciclista)
        {
            var cartao = new MeioDePagamentoViewModel
            {
                Numero = Ciclista.MeioDePagamento.Numero,
                NomeTitular = Ciclista.MeioDePagamento.NomeTitular,
                Validade = Ciclista.MeioDePagamento.Validade,
                CVV = Ciclista.MeioDePagamento.CVV
            };

            var request = JsonContent.Create(cartao);

            var response = await HttpClient.PostAsync(externoAPI + "/validaCartaoDeCredito", request);

             response.EnsureSuccessStatusCode();

            var result = _mapper.Map<CiclistaInsertViewModel, CiclistaViewModel>(Ciclista);
            result.Id = dict.Count;
            dict.Add(dict.Count, result);
            return (result);
        }

        public CiclistaViewModel GetCiclista(int id)
        {
            return dict.ElementAt(id).Value;
        }

        public CiclistaViewModel UpdateCiclista(CiclistaEditViewModel ciclistaNovo, int id)
        {
            var ciclistaAntigo = dict.ElementAt(id).Value;
            var result = _mapper.Map(ciclistaNovo, ciclistaAntigo);
            dict[id] = result;
            return (result);
        }

        public CiclistaViewModel UpdateCartao(MeioDePagamentoViewModel cartaoNovo, int id)
        {
            var ciclista = dict.ElementAt(id).Value;
            ciclista.MeioDePagamento = cartaoNovo;
            dict[id] = ciclista;
            return (ciclista);
        }

        public CiclistaViewModel Activate (int id)
        {
            dict[id].EmailConfirmado = true;
            return dict.ElementAt(id).Value;
        }

        public bool Contains (int id)
        {
            if (dict.ContainsKey(id))
            {
                return true;
            }
            return false;
        }

        public List<CiclistaViewModel> GetAll()
        {
            List<CiclistaViewModel> result = new();
            Dictionary<int, CiclistaViewModel>.ValueCollection objects = dict.Values;
            foreach (var value in objects)
            {
                result.Add(value);
            }
            return result;
        }

        public bool IsEmailRegistered (string email)
        {
            var lista = GetAll();
            foreach (var item in lista)
            {
                if (item.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public int ReturnSize()
        {
            return dict.Count;
        }

    }
}