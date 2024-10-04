using LaboratoryBackEnd.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace LaboratoryBackEnd.Models
{
    [Table("empresas")]
    public class Empresa : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [StringLength(14)]  // Sugestão opcional para garantir o tamanho do CNPJ
        [Column("cnpj")]
        public string Cnpj { get => _cnpj; set => _cnpj = Regex.Replace(value, @"[^\d]", ""); }
        private string _cnpj;

        [Required, StringLength(255)]
        [Column("razao_social")]
        public string RazaoSocial { get; set; }

        [StringLength(255)]
        [Column("nome_fantasia")]
        public string NomeFantasia { get; set; }

        [StringLength(255)]
        [Column("endereco")]
        public string Endereco { get; set; }

        [StringLength(20)]
        [Column("telefone")]
        public string Telefone { get; set; }

        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Column("data_abertura")]
        public DateTime? DataAbertura { get; set; }

        [StringLength(255)]
        [Column("natureza_juridica")]
        public string NaturezaJuridica { get; set; }

        [StringLength(50)]
        [Column("situacao_cadastral")]
        public string SituacaoCadastral { get; set; }

        [Column("capital_social")]
        [Precision(19, 2)]
        public decimal? CapitalSocial { get; set; }
    }
}