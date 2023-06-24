using AutoMapper;
using Aluguel.API.ViewModels;

namespace Aluguel.API.Services
{
    public interface ICiclistaService
    {
        public CiclistaViewModel CreateCiclista(CiclistaInsertViewModel Ciclista);
        public CiclistaViewModel GetCiclista(int id);
        public CiclistaViewModel UpdateCiclista(CiclistaEditViewModel Ciclista, int id);
        public bool Contains(int id);
        public List<CiclistaViewModel> GetAll();
        public CiclistaViewModel Activate(int id);
        public bool IsEmailRegistered(string email);
        public CiclistaViewModel UpdateCartao(MeioDePagamentoViewModel cartaoNovo, int id);
        //public CiclistaViewModel DeleteCiclista(int id);
    }

    public class CiclistaService : ICiclistaService
    {
        private static readonly Dictionary<int, CiclistaViewModel> dict = new();

        private readonly IMapper _mapper;

        public CiclistaService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CiclistaViewModel CreateCiclista(CiclistaInsertViewModel Ciclista)
        {
            var result = _mapper.Map<CiclistaInsertViewModel, CiclistaViewModel>(Ciclista);
            result.Id = dict.Count;
            dict.Add(dict.Count, result);
            return (result);
        }

        public CiclistaViewModel GetCiclista(int id)
        {
            return dict.ElementAt(id).Value;
        }


        public CiclistaViewModel UpdateCiclista(CiclistaEditViewModel CiclistaNovo, int id)
        {
            var CiclistaAntigo = dict.ElementAt(id).Value;
            var result = _mapper.Map(CiclistaNovo, CiclistaAntigo);
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

        //public CiclistaViewModel DeleteCiclista(int id)
        //{
        //    dict[id].Status = "Excluida";
        //    return dict.ElementAt(id).Value;
        //}

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