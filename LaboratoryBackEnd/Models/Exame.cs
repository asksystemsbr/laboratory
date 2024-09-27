using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Azure.Core.HttpHeader;
using System.Diagnostics.Metrics;

namespace LaboratoryBackEnd.Models
{
    [Table("exames")]
    public class Exame : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }  // Chave primária

        [MaxLength(255)]
        [Column("CODIGO_EXAME")]
        public string? CodigoExame { get; set; }  // EXAME (máximo de 255 caracteres)

        [MaxLength(255)]
        [Column("EXAME")]
        public string? NomeExame { get; set; }  // EXAME (máximo de 255 caracteres)

        [Column("PRAZO")]
        public int? Prazo { get; set; }  // PRAZO (número inteiro)

        [MaxLength(100)]
        [Column("METODO")]
        public string? Metodo { get; set; }  // METODO (máximo de 100 caracteres)

        [MaxLength(500)]
        [Column("PREPARO")]
        public string? Preparo { get; set; }  // PREPARO (máximo de 500 caracteres)

        [MaxLength(500)]
        [Column("PREPAROF")]
        public string? PreparoF { get; set; }  // PREPAROF (máximo de 500 caracteres)

        [MaxLength(500)]
        [Column("PREPAROC")]
        public string? PreparoC { get; set; }  // PREPAROC (máximo de 500 caracteres)

        [Column("AGENDA")]
        public bool? Agenda { get; set; }  // AGENDA (booleano)

        [MaxLength(500)]
        [Column("AGENDASRELACIONADAS")]
        public string? AgendassRelacionadas { get; set; }  // AGENDASRELACIONADAS (máximo de 500 caracteres)

        [MaxLength(500)]
        [Column("SINONIMOS")]
        public string? Sinonimos { get; set; }  // SINONIMOS (máximo de 500 caracteres)

        [Column("DISSOCIAR")]
        public bool? Dissociar { get; set; }  // DISSOCIAR (booleano)

        [MaxLength(500)]
        [Column("FORMULARIO")]
        public string? Formulario { get; set; }  // FORMULARIO (máximo de 500 caracteres)

        [MaxLength(1000)]
        [Column("INSTRUCOESDEPREPARO")]
        public string? InstrucoesPreparo { get; set; }  // INSTRUCOESDEPREPARO (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("COLETA")]
        public string? Coleta { get; set; }  // COLETA (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("DISTRIBUICAO")]
        public string? Distribuicao { get; set; }  // DISTRIBUICAO (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("LEMBRETES")]
        public string? Lembretes { get; set; }  // LEMBRETES (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("TECNICADECOLETA")]
        public string? TecnicaDeColeta { get; set; }  // TECNICADECOLETA (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("ALERTASRECEP")]
        public string? AlertasRecep { get; set; }  // ALERTASRECEP (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("ALERTASRECEPOS")]
        public string? AlertasRecepOs { get; set; }  // ALERTASRECEPOS (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("ALERTAS")]
        public string? Alertas { get; set; }  // ALERTAS (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("ALERTASPOS")]
        public string? AlertasPos { get; set; }  // ALERTASPOS (máximo de 1000 caracteres)

        [MaxLength(50)]
        [Column("SLEXAMESREF_TABELA_COD")]
        public string? SlExamesRefTabelaCod { get; set; }  // SLEXAMESREF_TABELA_COD (máximo de 50 caracteres)

        [MaxLength(255)]
        [Column("SLEXAMESREF_TABELA_EXAME")]
        public string? SLExamesRefTabelaExame { get; set; }  // SLEXAMESREF_TABELA_EXAME (máximo de 255 caracteres)

        [MaxLength(50)]
        [Column("SLEXAMESREF_TABELA_CONV")]
        public string? SLExamesRefTabelaConv { get; set; }  // SLEXAMESREF_TABELA_CONV (máximo de 50 caracteres)

        [MaxLength(100)]
        [Column("SLEXAMESREF_TABELA_PLANO")]
        public string? SLExamesRefTabelaPlano { get; set; }  // SLEXAMESREF_TABELA_PLANO (máximo de 100 caracteres)

        [MaxLength(50)]
        [Column("SLEXAMESREF_TABELA_AUT")]
        public string? SLExamesRefTabelaAut { get; set; }  // SLEXAMESREF_TABELA_AUT (máximo de 50 caracteres)

        [Column("SLEXAMESREF_TABELA_VALOR", TypeName = "decimal(18, 2)")]
        public decimal? SLExamesRefTabelaValor { get; set; }  // SLEXAMESREF_TABELA_VALOR (valor decimal com 18 dígitos e 2 casas decimais)

        [Column("ESTABILIDADE")]
        public string? Estabilidade { get; set; }

        [Column("TUSS")]
        public string? Tuss { get; set; }

        [Column("MEIOS_DE_COLETA")]
        public string? MeiosDeColeta { get; set; }

        [Column("COLETAPAC")]
        public string? ColetaPac { get; set; }

        [Column("COLETAPACF")]
        public string? ColetaPacF { get; set; }

        [Column("COLETAPACC")]
        public string? ColetaPacC { get; set; }

        [Column("MATERIAL_APOIO_ID")]
        public int MaterialApoioId { get; set; }

        [Column("EPECIALIDADE_ID")]
        public int EspecialidadeId { get; set; }
        [Column("SETOR_ID")]
        public int SetorId { get; set; }

        [Column("DESTINO_ID")]
        public int DestinoId { get; set; }  // DESTINO (máximo de 500 caracteres)

        [Column("VOLUMEMINIMO")]
        public string? VolumeMinimo { get; set; }

        [Column("CODIGO_EXAME_APOIO")]
        public string? CodigoExameApoio { get; set; }

        [Column("PRAZO_APOIO")]
        public string? PrazoApoio { get; set; }

        [Column("VALOR_APOIO")]
        public string? ValorApoio { get; set; }

        [Column("VERSAO_APOIO")]
        public string? VersaoApoio { get; set; }


        [Column("DIAS_REALIZACAO_APOIO")]
        public string? DiasRealizacaoApoio { get; set; }
    }
}
