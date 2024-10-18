using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("convenio")]
    public class Convenio : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [StringLength(255)]
        [Column("descricao")]
        public string? Descricao { get; set; } // Campo opcional

        [Column("endereco_id")]
        public int EnderecoId { get; set; } // Campo opcional

        // Propriedade de navegação opcional
        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }

        [Column("digitos_validar_matricula")]
        public int? DigitosValidarMatricula { get; set; } // Campo para quantidade de dígitos

        [Column("liquidacao")]
        public string? Liquidacao { get; set; } // Via Fatura ou Via Caixa

        [Column("codigo_prestador")]
        public string? CodigoPrestador { get; set; } // Código do prestador

        [Column("versao_tiss")]
        public string? VersaoTiss { get; set; } // Versão da TISS

        [Column("cnes_convenio")]
        public string? CnesConvenio { get; set; } // CNES do convênio

        [Column("cod_operadora_tiss")]
        public string? CodOperadoraTiss { get; set; } // Código da operadora TISS

        [Column("cod_operadora")]
        public string? CodOperadora { get; set; } // Código operadora para autorização

        [Column("url_integracao")]
        public string? UrlIntegracao { get; set; } // URL da API de integração

        [Column("inicio_numeracao")]
        public string? InicioNumeracao { get; set; } // Início da numeração

        [Column("usuario_acesso_web")]
        [StringLength(100)]
        public string? UsuarioAcessoWeb { get; set; } // Usuário de acesso web

        [Column("senha_acesso_web")]
        [StringLength(100)]
        public string? SenhaAcessoWeb { get; set; } // Senha de acesso web

        [Column("envio_cronograma")]
        public int? EnvioCronograma { get; set; } // Envio cronograma

        [Column("ate_cronograma")]
        public DateTime? AteCronograma { get; set; } // Até o cronograma

        [Column("vencimento_cronograma")]
        public DateTime? VencimentoCronograma { get; set; } // Data de vencimento do cronograma

        [Column("observacoes")]
        public string? Observacoes { get; set; } // Campo de observações

        [Column("instrucoes")]
        public string? Instrucoes { get; set; } // Campo de instruções

        [Column("empresa_id")]
        public int? EmpresaId { get; set; } // Relacionamento com a tabela de empresas
    }
}