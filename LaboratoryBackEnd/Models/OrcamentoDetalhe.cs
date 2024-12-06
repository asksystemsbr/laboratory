using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("orcamento_detalhe")]
    public class OrcamentoDetalhe:IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("orcamento_id")]
        public int? OrcamentoId { get; set; }

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
