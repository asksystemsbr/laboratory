using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("agendamento_detalhe")]
    public class AgendamentoDetalhe : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("agendamento_id")]
        public int? AgendamentoId { get; set; }

        [Column("exame_id")]
        public int? ExameId { get; set; }

        [Column("valor")]
        public decimal? Valor { get; set; }

        [Column("data_coleta")]
        public DateTime? DataColeta { get; set; }

        [Column("horario_id")]
        public int? HorarioId { get; set; }
    }
}
