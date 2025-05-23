﻿using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("orcamento_pagamento")]
    public class OrcamentoPagamento : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("pagamento_id")]
        public int? PagamentoId { get; set; }

        [Column("valor")]
        public decimal? Valor { get; set; }

        [Column("orcamento_id")]
        public int? OrcamentoId { get; set; }

        
        [Column("data_pagamento")]
        public DateTime? DataPagamento { get; set; }
    }
}
