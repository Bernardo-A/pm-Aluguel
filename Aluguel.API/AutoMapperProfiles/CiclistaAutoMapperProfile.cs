using Aluguel.API.ViewModels;
using AutoMapper;

namespace Aluguel.API.AutoMapperProfiles
{
    public class CiclistaAutoMapperProfile : Profile
    {
        public CiclistaAutoMapperProfile() {
            CreateMap<CiclistaInsertViewModel, CiclistaViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.EmailConfirmado, opt => opt.Ignore());
            CreateMap<CiclistaEditViewModel, CiclistaViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.Senha, opt => opt.Ignore())
                .ForMember(dest => dest.MeioDePagamento, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmado, opt => opt.Ignore());
        }
    }
}
