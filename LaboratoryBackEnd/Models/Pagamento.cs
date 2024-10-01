using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("pagamentos")]
    public class Pagamento : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pagamento_id")]
        public int ID { get; set; }

        [Column("compra_id")]
        public int? CompraId { get; set; }  // Permite nulo

        [Required]
        [Column("metodo_pagamento_id")]
        public int MetodoPagamentoId { get; set; }  // Obrigatório

        [Column("data_pagamento")]
        public DateTime? DataPagamento { get; set; }  // Permite nulo

        [Column("valor_pago", TypeName = "decimal(10,2)")]
        public decimal? ValorPago { get; set; }  // Permite nulo

        [Required]
        [Column("status_pagamento_id")]
        public int StatusPagamentoId { get; set; }  // Obrigatório

        [Column("boleto_ocr", TypeName = "text")]
        public string? BoletoOCR { get; set; }  // Permite nulo

        // Propriedades de navegação
        //[ForeignKey("CompraId")]
        //public virtual Compra Compra { get; set; }

        [ForeignKey("MetodoPagamentoId")]
        public virtual MetodosPagamento MetodoPagamento { get; set; }

        [ForeignKey("StatusPagamentoId")]
        public virtual StatusPagamento StatusPagamento { get; set; }
    }
}