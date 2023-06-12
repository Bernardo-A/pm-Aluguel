using Aluguel.API.ViewModels;
using AutoMapper;

namespace Aluguel.API.AutoMapperProfiles
{
    public class CiclitaAutoMapperProfile : Profile
    {
        public CiclitaAutoMapperProfile() {
            CreateMap<CiclistaInsertViewModel, CiclistaViewModel>();
        }
    }
}
