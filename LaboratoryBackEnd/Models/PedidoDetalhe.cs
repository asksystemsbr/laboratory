using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("pedido_detalhe")]
    public class PedidoDetalhe : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("pedido_id")]
        public int? PedidoId { get; set; }

        [Column("exame_id")]
        public int? ExameId { get; set; }

        [Column("valor")]
        public decimal? Valor { get; set; }

        [Column("data_coleta")]
        public DateTime? DataColeta { get; set; }
    }
}
