using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("plano")]
    public class Plano : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [StringLength(255)]
        [Column("descricao")]
        public string? Descricao { get; set; }  // Permite nulo

        [Column("tabela_preco_id")]
        public int? TabelaPrecoId { get; set; }

        [Column("convenio_id")]
        public int? ConvenioId { get; set; }
        
        [Column("custo_horario", TypeName = "decimal(10,4)")]
        public decimal? CustoHorario { get; set; }

        [Column("custo_filme", TypeName = "decimal(10,4)")]
        public decimal? Filme { get; set; }

        [Column("codigo_arnb")]
        public string? CodigoArnb { get; set; }
    }
}