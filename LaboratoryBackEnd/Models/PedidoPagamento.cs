using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("pedido_pagamento")]
    public class PedidoPagamento : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("pagamento_id")]
        public int? PagamentoId { get; set; }

        [Column("valor")]
        public decimal? Valor { get; set; }

        [Column("pedido_id")]
        public int? PedidoId { get; set; }

        [Column("data_pagamento")]
        public DateTime? DataPagamento { get; set; }

    }
}
