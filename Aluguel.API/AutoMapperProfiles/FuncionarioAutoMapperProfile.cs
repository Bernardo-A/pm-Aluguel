using Aluguel.API.ViewModels;
using AutoMapper;

namespace Aluguel.API.AutoMapperProfiles
{
    public class FuncionarioAutoMapperProfile : Profile
    {
        public FuncionarioAutoMapperProfile() {
            CreateMap<FuncionarioInsertViewModel, FuncionarioViewModel>();
            CreateMap<FuncionarioEditViewModel, FuncionarioViewModel>();
        }
    }
}
