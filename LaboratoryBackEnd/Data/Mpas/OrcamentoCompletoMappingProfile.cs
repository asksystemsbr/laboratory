using AutoMapper;
using LaboratoryBackEnd.Data.DTO;
using LaboratoryBackEnd.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LaboratoryBackEnd.Data.Mpas
{
    public class OrcamentoCompletoMappingProfile : Profile
    {
        public OrcamentoCompletoMappingProfile()
        {
            // Mapeamento entre Orcamento e Pedido
            CreateMap<OrcamentoCabecalho, PedidoCabecalho>();
            CreateMap<OrcamentoDetalhe, PedidoDetalhe>();
            CreateMap<OrcamentoPagamento, PedidoPagamento>();

            CreateMap<OrcamentoCompletoDto, PedidoCompletoDto>()
                .ForMember(dest => dest.PedidoCabecalho, opt => opt.MapFrom(src => src.OrcamentoCabecalho))
                .ForMember(dest => dest.PedidoDetalhe, opt => opt.MapFrom(src => src.OrcamentoDetalhe))
                .ForMember(dest => dest.PedidoPagamento, opt => opt.MapFrom(src => src.OrcamentoPagamento));
        }
    }
}
