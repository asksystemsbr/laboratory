using AutoMapper;
using LaboratoryBackEnd.Data.DTO;
using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Data.Mpas
{
    public class AgendamentoHorarioMapperProfile: Profile
    {

        public AgendamentoHorarioMapperProfile()
        {
            // Mapear de DTO para Entidade
            CreateMap<AgendamentoHorarioDto, AgendamentoHorario>()
                .ForMember(dest => dest.ID, opt => opt.Ignore()) // ID será gerado pelo banco
                .ForMember(dest => dest.RecepcaoId, opt => opt.MapFrom(src =>src.UnidadeId))
                .ForMember(dest => dest.HoraInicio, opt => opt.MapFrom(src => TimeSpan.Parse(src.HoraInicio))) // Conversão de string para TimeSpan
                .ForMember(dest => dest.HoraFim, opt => opt.MapFrom(src => TimeSpan.Parse(src.HoraFim)));     // Conversão de string para TimeSpan

            // Mapear de Entidade para DTO
            CreateMap<AgendamentoHorario, AgendamentoHorarioDto>()
                .ForMember(dest => dest.Unidade, opt => opt.Ignore()) // Unidade vem de uma outra tabela
                .ForMember(dest => dest.Convenio, opt => opt.Ignore()) // Convenio vem de uma outra tabela
                .ForMember(dest => dest.Plano, opt => opt.Ignore()) // Plano vem de uma outra tabela
                .ForMember(dest => dest.Solicitante, opt => opt.Ignore()) // Solicitante vem de uma outra tabela
                .ForMember(dest => dest.Exame, opt => opt.Ignore()) // Exame vem de uma outra tabela
                .ForMember(dest => dest.HoraInicio, opt => opt.MapFrom(src => src.HoraInicio.ToString(@"hh\:mm"))) // Conversão para string
                .ForMember(dest => dest.HoraFim, opt => opt.MapFrom(src => src.HoraFim.ToString(@"hh\:mm")));       // Conversão para string
        }
    }
}
