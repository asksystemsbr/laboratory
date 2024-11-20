using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Data.DTO
{
    public class AgendamentoHorarioDto
    {
        public int ID { get; set; }
        public int UnidadeId { get; set; }
        public int ConvenioId { get; set; }
        public int PlanoId { get; set; }
        public int SolicitanteId { get; set; }
        public int ExameId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        //public TimeSpan HoraInicio { get; set; } // Ex.: 09:00
        //public TimeSpan HoraFim { get; set; }   // Ex.: 10:00

        private TimeSpan _horaInicio;
        public string HoraInicio
        {
            get => _horaInicio.ToString(@"hh\:mm");
            set
            {
                if (!TimeSpan.TryParseExact(value, @"hh\:mm", null, out _horaInicio))
                {
                    throw new ArgumentException("Invalid TimeSpan format for HoraInicio. Expected 'HH:mm'.");
                }
            }
        }

        private TimeSpan _horaFim;
        public string HoraFim
        {
            get => _horaFim.ToString(@"hh\:mm");
            set
            {
                if (!TimeSpan.TryParseExact(value, @"hh\:mm", null, out _horaFim))
                {
                    throw new ArgumentException("Invalid TimeSpan format for HoraFim. Expected 'HH:mm'.");
                }
            }
        }
        public int DuracaoMinutos { get; set; } // Ex.: 30
        public int IntervaloMinutos { get; set; } // Ex.: 10


        public string? Unidade { get; set; }
        public string? Convenio { get; set; }
        public string? Plano { get; set; }
        public string? Solicitante { get; set; }
        public string? Exame { get; set; }

        public List<AgendamentoHorarioGerado>? lstGerados { get; set; }
    }

}
