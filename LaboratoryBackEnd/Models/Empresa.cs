using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("empresas")]
    public class Empresa : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, StringLength(14)]
        public string Cnpj { get; set; }

        [Required, StringLength(255)]
        public string RazaoSocial { get; set; }

        [StringLength(255)]
        public string NomeFantasia { get; set; }

        [StringLength(255)]
        public string Endereco { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DateTime? DataAbertura { get; set; }

        [StringLength(255)]
        public string NaturezaJuridica { get; set; }

        [StringLength(50)]
        public string SituacaoCadastral { get; set; }

        public decimal? CapitalSocial { get; set; }
    }
}