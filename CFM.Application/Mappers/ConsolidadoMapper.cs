using AutoMapper;
using CFM.Application.DTOs;
using CFM.Domain.Entities;
using CFM.Domain.Enums;

namespace CFM.Application.Mappers
{
    public class ConsolidadoMapper : Profile
    {
        public ConsolidadoMapper()
        {
            CreateMap<Consolidado, ConsolidadoDTO>();

            CreateMap<ConsolidadoDTO, Consolidado>()
                .ForMember(dest => dest.ValorDespesas, opt => opt.MapFrom(src => src.ValorDespesas))
                .ForMember(dest => dest.ValorReceitas, opt => opt.MapFrom(src => src.ValorReceitas))
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio))
                .ForMember(dest => dest.DataFim, opt => opt.MapFrom(src => src.DataFim));
        }
    }
}
