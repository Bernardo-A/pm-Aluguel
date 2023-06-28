using AutoMapper;
using Aluguel.API.ViewModels;

namespace Aluguel.API.Services
{
    public interface IFuncionarioService
    {
        public FuncionarioViewModel CreateFuncionario(FuncionarioInsertViewModel Funcionario);
        public FuncionarioViewModel GetFuncionario(int id);
        public FuncionarioViewModel UpdateFuncionario(FuncionarioEditViewModel funcionarioNovo, int id);
        public FuncionarioViewModel DeleteFuncionario(int id);
        public bool Contains(int id);
        public List<FuncionarioViewModel> GetAll();
        public bool IsEmpty();
    }

    public class FuncionarioService : IFuncionarioService
    {
        private static readonly Dictionary<int, FuncionarioViewModel> dict = new();

        private readonly IMapper _mapper;

        public FuncionarioService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public FuncionarioViewModel CreateFuncionario(FuncionarioInsertViewModel Funcionario)
        {
            var result = _mapper.Map<FuncionarioInsertViewModel, FuncionarioViewModel>(Funcionario);
            result.Id = dict.Count;
            dict.Add(dict.Count, result);
            return (result);
        }

        public FuncionarioViewModel GetFuncionario(int id)
        {
            return dict.ElementAt(id).Value;
        }

        public FuncionarioViewModel UpdateFuncionario(FuncionarioEditViewModel funcionarioNovo, int id)
        {
            var funcionarioAntigo = dict.ElementAt(id).Value;
            var result = _mapper.Map(funcionarioNovo, funcionarioAntigo);
            dict[id] = result;
            return (result);
        }

        public FuncionarioViewModel DeleteFuncionario(int id)
        {
            dict[id].Habilitado = false;
            return dict.ElementAt(id).Value;
        }

        public List<FuncionarioViewModel> GetAll()
        {
            List<FuncionarioViewModel> result = new();
            Dictionary<int, FuncionarioViewModel>.ValueCollection objects = dict.Values;
            foreach (var value in objects)
            {
                result.Add(value);
            }
            return result;
        }

        public bool IsEmpty()
        {
            return dict.Count == 0;
        }

        public int ReturnSize()
        {
            return dict.Count;
        }

        public bool Contains(int id)
        {
            if (dict.ContainsKey(id))
            {
                return true;
            }
            return false;
        }

    }
}