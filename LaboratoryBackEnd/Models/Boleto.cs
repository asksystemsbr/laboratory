using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("boleto")]
    public class Boleto:IIdentifiable
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("numero_documento")]
        [StringLength(255)]
        public string NumeroDocumento { get; set; }

        [Required]
        [Column("nosso_numero")]
        [StringLength(255)]
        public string NossoNumero { get; set; }

        [Required]
        [Column("data_emissao")]
        public DateTime DataEmissao { get; set; }

        [Required]
        [Column("data_vencimento")]
        public DateTime DataVencimento { get; set; }

        [Required]
        [Column("valor_original", TypeName = "decimal(10, 2)")]
        [DataType(DataType.Currency)]
        public decimal ValorOriginal { get; set; }

        [Column("valor_pago", TypeName = "decimal(10, 2)")]
        [DataType(DataType.Currency)]
        public decimal? ValorPago { get; set; }

        [Column("data_pagamento")]
        public DateTime? DataPagamento { get; set; }

        [Required]
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        // Navigation property
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
    }
}
