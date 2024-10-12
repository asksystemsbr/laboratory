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

        [StringLength(255)]
        [Column("e_mail_1")]
        public string? Email1 { get; set; }

        [StringLength(255)]
        [Column("e_mail_2")]
        public string? Email2 { get; set; }

        [StringLength(255)]
        [Column("e_mail_3")]
        public string? Email3 { get; set; }

        [StringLength(255)]
        [Column("url_integracao")]
        public string? UrlIntegracao { get; set; }

        [StringLength(255)]
        [Column("nome_banco")]
        public string? NomeBanco { get; set; }

        [StringLength(255)]
        [Column("agencia_banco")]
        public string? AgenciaBanco { get; set; }

        [StringLength(255)]
        [Column("conta_banco")]
        public string? ContaBanco { get; set; }

        [Column("IRPF")]
        [Precision(19, 2)]
        public decimal? Irpf { get; set; }

        [Column("PIS")]
        [Precision(19, 2)]
        public decimal? Pis { get; set; }

        [Column("COFINS")]
        [Precision(19, 2)]
        public decimal? Cofins { get; set; }

        [Column("CSLL")]
        [Precision(19, 2)]
        public decimal? Csll { get; set; }

        [Column("ISS")]
        [Precision(19, 2)]
        public decimal? Iss { get; set; }

        [Column("reter_ISS")]
        public bool? ReterIss { get; set; }

        [Column("reter_IR")]
        public bool? ReterIr { get; set; }

        [Column("reter_PCC")]
        public bool? ReterPcc { get; set; } // Retém PIS, COFINS, CSLL

        [Column("optante_simples")]
        public bool? OptanteSimples { get; set; }

        [StringLength(255)]
        [Column("NS_CERTIFICADO_DIGITAL")]
        public string? NumeroSerialCertificadoDigital { get; set; }

        [StringLength(255)]
        [Column("CNES")]
        public string? Cnes { get; set; }

        [Column("categoria_empresa_id")]
        public int? CategoriaEmpresaId { get; set; }

        [Column("endereco_id")]
        public int EnderecoId { get; set; } // Campo opcional

        // Propriedade de navegação opcional
        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }
    }
}