using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("agendamento_pagamento")]
    public class AgendamentoPagamento : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("pagamento_id")]
        public int? PagamentoId { get; set; }

        [Column("valor")]
        public decimal? Valor { get; set; }

        [Column("agendamento_id")]
        public int? AgendamentoId { get; set; }

    }
}
