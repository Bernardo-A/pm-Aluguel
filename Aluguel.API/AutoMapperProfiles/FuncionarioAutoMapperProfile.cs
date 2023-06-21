using Aluguel.API.ViewModels;
using AutoMapper;

namespace Aluguel.API.AutoMapperProfiles
{
    public class FuncionarioAutoMapperProfile : Profile
    {
        public FuncionarioAutoMapperProfile() {
            CreateMap<FuncionarioInsertViewModel, FuncionarioViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.Habilitado, opt => opt.MapFrom(src => true));
            CreateMap<FuncionarioEditViewModel, FuncionarioViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.CPF, opt => opt.Ignore())
                .ForMember(dest => dest.Habilitado, opt => opt.Ignore());
        }
    }
}
