using AutoMapper;
using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Data.Mpas
{
    public class AgendamentoToOrcamentoMappingProfile:Profile
    {
        public AgendamentoToOrcamentoMappingProfile()
        {
            // Mapeamento de AgendamentoCabecalho para OrcamentoCabecalho
            CreateMap<AgendamentoCabecalho, OrcamentoCabecalho>();

            // Mapeamento de AgendamentoDetalhe para OrcamentoDetalhe
            CreateMap<AgendamentoDetalhe, OrcamentoDetalhe>()
                .ForMember(dest => dest.OrcamentoId, opt => opt.Ignore()); // Será configurado no runtime.

            // Mapeamento de AgendamentoPagamento para OrcamentoPagamento
            CreateMap<AgendamentoPagamento, OrcamentoPagamento>()
                .ForMember(dest => dest.OrcamentoId, opt => opt.Ignore()); // Será configurado no runtime.
        }
    }
}
