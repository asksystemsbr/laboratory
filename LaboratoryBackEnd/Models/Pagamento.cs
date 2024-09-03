using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Model
{
    [Table("pagamentos")]
    public class Pagamento : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pagamento_id")]
        public int ID { get; set; }

        [Column("compra_id")]
        public int? CompraId { get; set; }

        [Column("metodo_pagamento_id")]
        public int? MetodoPagamentoId { get; set; }

        [Column("data_pagamento")]
        public DateTime? DataPagamento { get; set; }

        //[Column(TypeName = "decimal(10,2)", Name = "valor_pago")]
        public decimal? ValorPago { get; set; }

        [Column("status_pagamento_id")]
        public int? StatusPagamentoId { get; set; }

        [Column("boleto_ocr", TypeName = "text")]
        public string BoletoOCR { get; set; }

        //[ForeignKey("CompraId")]
        //public virtual Compra Compra { get; set; }

        //[ForeignKey("MetodoPagamentoId")]
        //public virtual MetodoPagamento MetodoPagamento { get; set; }

        [ForeignKey("StatusPagamentoId")]
        public virtual StatusPagamento StatusPagamento { get; set; }
    }
}
