using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Data.DTO
{
    public class AgendamentoHorarioCompletoDto
    {
        public AgendamentoHorario AgendamentoHorario { get; set; }
        public List<AgendamentoHorarioGerado> AgendamentoHorarioGerado { get; set; }
    }
}
