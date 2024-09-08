using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("contas_historico")]
    public class ContasHistorico:IIdentifiable
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("conta")]
        [StringLength(255)]
        public string Conta { get; set; }

        [Required]
        [Column("valor", TypeName = "decimal(10, 3)")]
        public decimal Valor { get; set; }

        [Required]
        [Column("tipo")]
        [StringLength(255)]
        public string Tipo { get; set; }

        [Required]
        [Column("data_pagamento")]
        public DateTime DataPagamento { get; set; }

        [Required]
        [Column("id_conta")]
        public int IdConta { get; set; }

        // Navigation property
        [ForeignKey("IdConta")]
        public Contas ContaNavigation { get; set; }
    }
}
