using AutoMapper;
using LaboratoryBackEnd.Data.DTO;
using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Data.Mpas
{
    public class AgendamentoDetalheMappingProfile:Profile
    {
        public AgendamentoDetalheMappingProfile()
        {
            // Mapear de DTO para Entidade
            CreateMap<AgendamentoDetalheDto, AgendamentoDetalhe>();

            // Mapear de Entidade para DTO
            CreateMap<AgendamentoDetalhe, AgendamentoDetalheDto>();
        }
    }
}
