using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("agendamento_horario")]
    public class AgendamentoHorario : IIdentifiable
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("recepcao_id")]
        public int? RecepcaoId { get; set; }

        [Column("convenio_id")]
        public int? ConvenioId { get; set; }

        [Column("plano_id")]
        public int? PlanoId { get; set; }

        [Column("solicitante_id")]
        public int? SolicitanteId { get; set; }

        [Column("exame_id")]
        public int? ExameId { get; set; }

        [Column("dataInicio ")]
        public DateTime? DataInicio { get; set; }

        [Column("horaInicio ")]
        public TimeSpan HoraInicio { get; set; } // Ex.: 09:00
        
        [Column("horaFim ")]
        public TimeSpan HoraFim { get; set; }   // Ex.: 10:00

        [Column("duracaoMinutos ")]
        public int DuracaoMinutos { get; set; }

        [Column("intervaloMinutos ")]
        public int IntervaloMinutos { get; set; }

    }
}
