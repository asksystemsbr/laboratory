using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("exames")]
    public class Exame : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }

        [MaxLength(255)]
        [Column("CODIGO_EXAME")]
        public string? CodigoExame { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("EXAME")]
        public string NomeExame { get; set; }

        [Column("PRAZO")]
        public int? Prazo { get; set; }

        [MaxLength(100)]
        [Column("METODO")]
        public string? Metodo { get; set; }

        [MaxLength(500)]
        [Column("PREPARO")]
        public string? Preparo { get; set; }

        [MaxLength(500)]
        [Column("PREPAROF")]
        public string? PreparoF { get; set; }

        [MaxLength(500)]
        [Column("PREPAROC")]
        public string? PreparoC { get; set; }

        [Column("AGENDA")]
        public bool? Agenda { get; set; }

        [MaxLength(500)]
        [Column("AGENDASRELACIONADAS")]
        public string? AgendasRelacionadas { get; set; }

        [MaxLength(500)]
        [Column("SINONIMOS")]
        public string? Sinonimos { get; set; }

        [Column("DISSOCIAR")]
        public bool? Dissociar { get; set; }

        [MaxLength(500)]
        [Column("FORMULARIO")]
        public string? Formulario { get; set; }

        [MaxLength(1000)]
        [Column("INSTRUCOESDEPREPARO")]
        public string? InstrucoesPreparo { get; set; }

        [MaxLength(1000)]
        [Column("COLETA")]
        public string? Coleta { get; set; }

        [MaxLength(1000)]
        [Column("DISTRIBUICAO")]
        public string? Distribuicao { get; set; }

        [MaxLength(1000)]
        [Column("LEMBRETES")]
        public string? Lembretes { get; set; }

        [MaxLength(1000)]
        [Column("TECNICADECOLETA")]
        public string? TecnicaDeColeta { get; set; }

        [MaxLength(1000)]
        [Column("ALERTASRECEP")]
        public string? AlertasRecep { get; set; }

        [MaxLength(1000)]
        [Column("ALERTASRECEPOS")]
        public string? AlertasRecepOs { get; set; }

        [MaxLength(1000)]
        [Column("ALERTAS")]
        public string? Alertas { get; set; }

        [MaxLength(1000)]
        [Column("ALERTASPOS")]
        public string? AlertasPos { get; set; }

        [MaxLength(50)]
        [Column("SLEXAMESREF_TABELA_COD")]
        public string? SlExamesRefTabelaCod { get; set; }

        [MaxLength(255)]
        [Column("SLEXAMESREF_TABELA_EXAME")]
        public string? SLExamesRefTabelaExame { get; set; }

        [MaxLength(50)]
        [Column("SLEXAMESREF_TABELA_CONV")]
        public string? SLExamesRefTabelaConv { get; set; }

        [MaxLength(100)]
        [Column("SLEXAMESREF_TABELA_PLANO")]
        public string? SLExamesRefTabelaPlano { get; set; }

        [MaxLength(50)]
        [Column("SLEXAMESREF_TABELA_AUT")]
        public string? SLExamesRefTabelaAut { get; set; }

        [Column("SLEXAMESREF_TABELA_VALOR", TypeName = "decimal(18, 2)")]
        public decimal? SLExamesRefTabelaValor { get; set; }

        [MaxLength(255)]
        [Column("ESTABILIDADE")]
        public string? Estabilidade { get; set; }

        [MaxLength(255)]
        [Column("TUSS")]
        public string? Tuss { get; set; }

        [MaxLength(255)]
        [Column("MEIOS_DE_COLETA")]
        public string? MeiosDeColeta { get; set; }

        [MaxLength(255)]
        [Column("COLETAPAC")]
        public string? ColetaPac { get; set; }

        [MaxLength(255)]
        [Column("COLETAPACF")]
        public string? ColetaPacF { get; set; }

        [MaxLength(255)]
        [Column("COLETAPACC")]
        public string? ColetaPacC { get; set; }

        [Column("MATERIAL_APOIO_ID")]
        public int MaterialApoioId { get; set; }

        [Column("especialidade_id")]
        public int? EspecialidadeId { get; set; }

        [Column("SETOR_ID")]
        public int? SetorId { get; set; }

        [Column("DESTINO_ID")]
        public int? DestinoId { get; set; }

        [MaxLength(255)]
        [Column("VOLUMEMINIMO")]
        public string? VolumeMinimo { get; set; }

        [MaxLength(255)]
        [Column("CODIGO_EXAME_APOIO")]
        public string? CodigoExameApoio { get; set; }

        [MaxLength(255)]
        [Column("PRAZO_APOIO")]
        public string? PrazoApoio { get; set; }

        [MaxLength(255)]
        [Column("VALOR_APOIO")]
        public string? ValorApoio { get; set; }

        [MaxLength(255)]
        [Column("VERSAO_APOIO")]
        public string? VersaoApoio { get; set; }

        [MaxLength(255)]
        [Column("DIAS_REALIZACAO_APOIO")]
        public string? DiasRealizacaoApoio { get; set; }
    }
}