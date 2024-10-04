using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("ordem_de_servico")]
    public class OrdemDeServico : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("os_id")]
        public int ID { get; set; }

        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]
        [Column("data_abertura")]
        public DateTime DataAbertura { get; set; }

        [Column("data_fechamento")]
        public DateTime? DataFechamento { get; set; }

        [Required]
        [Column("status_os_id")]
        public int StatusOsId { get; set; }

        [Required]
        [Column("descricao_problema", TypeName = "text")]
        public string DescricaoProblema { get; set; }

        [Column("observacoes", TypeName = "text")]
        public string? Observacoes { get; set; }
    }
}