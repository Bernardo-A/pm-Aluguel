using Aluguel.API.ViewModels;
using AutoMapper;

namespace Aluguel.API.AutoMapperProfiles
{
    public class CiclistaAutoMapperProfile : Profile
    {
        public CiclistaAutoMapperProfile() {
            CreateMap<CiclistaInsertViewModel, CiclistaViewModel>();
            CreateMap<CiclistaEditViewModel, CiclistaViewModel>();
        }
    }
}
