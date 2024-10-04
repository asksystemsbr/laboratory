using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaboratoryBackEnd.Models
{
    [Table("tabela_preco_itens")]
    public class TabelaPrecoItens : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("tabela_preco_id")]
        public int? TabelaPrecoId { get; set; }

        [Column("exame_id")]
        public int? ExameId { get; set; }

        [Column("valor")]
        public decimal? Valor { get; set; }

        [Column("custo_operacional")]
        public decimal? CustoOperacional { get; set; }

        [Column("custo_horario")]
        public decimal? CustoHorario { get; set; }

        [Column("filme")]
        public decimal? Filme { get; set; }

        [Column("codigo_arnb")]
        public string? CodigoArnb { get; set; }
    }
}