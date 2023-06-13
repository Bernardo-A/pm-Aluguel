using Aluguel.API.ViewModels;
using AutoMapper;

public interface ICiclistaService
{
    public class CiclistaService : ICiclistaService
    {
        public CiclistaInsertViewModel  GetCiclistaInsertViewModel()
        {
            var result = new CiclistaInsertViewModel();
            return result;
        }
    }
}




