using AutoMapper;
using CFM.Application.DTOs;
using CFM.Domain.Entities;
using CFM.Domain.Enums;

namespace CFM.Application.Mappers
{
    public class LancamentoMapper : Profile
    {
        public LancamentoMapper()
        {
            CreateMap<Lancamento, LancamentoDTO>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(x => x.Categoria));

            CreateMap<LancamentoDTO, Lancamento>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => Enum.Parse<CategoriaEnum>(src.Categoria.ToString())));
        }
    }
}
