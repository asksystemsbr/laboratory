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
        [Column("COD")]
        public int ID { get; set; }  // Chave primária

        [MaxLength(255)]
        [Column("CODIGO_EXAME")]
        public string CODIGO_EXAME { get; set; }  // EXAME (máximo de 255 caracteres)

        [MaxLength(255)]
        [Column("EXAME")]
        public string EXAME { get; set; }  // EXAME (máximo de 255 caracteres)

        [Column("PRAZO")]
        public int PRAZO { get; set; }  // PRAZO (número inteiro)

        [MaxLength(100)]
        [Column("METODO")]
        public string METODO { get; set; }  // METODO (máximo de 100 caracteres)

        [MaxLength(500)]
        [Column("PREPARO")]
        public string PREPARO { get; set; }  // PREPARO (máximo de 500 caracteres)

        [MaxLength(500)]
        [Column("PREPAROF")]
        public string PREPAROF { get; set; }  // PREPAROF (máximo de 500 caracteres)

        [MaxLength(500)]
        [Column("PREPAROC")]
        public string PREPAROC { get; set; }  // PREPAROC (máximo de 500 caracteres)

        [Column("AGENDA")]
        public bool AGENDA { get; set; }  // AGENDA (booleano)

        [MaxLength(500)]
        [Column("AGENDASRELACIONADAS")]
        public string AGENDASRELACIONADAS { get; set; }  // AGENDASRELACIONADAS (máximo de 500 caracteres)

        [MaxLength(500)]
        [Column("DESTINO")]
        public string DESTINO { get; set; }  // DESTINO (máximo de 500 caracteres)

        [MaxLength(500)]
        [Column("SINONIMOS")]
        public string SINONIMOS { get; set; }  // SINONIMOS (máximo de 500 caracteres)

        [Column("DISSOCIAR")]
        public bool DISSOCIAR { get; set; }  // DISSOCIAR (booleano)

        [MaxLength(500)]
        [Column("FORMULARIO")]
        public string FORMULARIO { get; set; }  // FORMULARIO (máximo de 500 caracteres)

        [MaxLength(1000)]
        [Column("INSTRUCOESDEPREPARO")]
        public string INSTRUCOESDEPREPARO { get; set; }  // INSTRUCOESDEPREPARO (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("COLETA")]
        public string COLETA { get; set; }  // COLETA (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("DISTRIBUICAO")]
        public string DISTRIBUICAO { get; set; }  // DISTRIBUICAO (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("LEMBRETES")]
        public string LEMBRETES { get; set; }  // LEMBRETES (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("TECNICADECOLETA")]
        public string TECNICADECOLETA { get; set; }  // TECNICADECOLETA (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("ALERTASRECEP")]
        public string ALERTASRECEP { get; set; }  // ALERTASRECEP (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("ALERTASRECEPOS")]
        public string ALERTASRECEPOS { get; set; }  // ALERTASRECEPOS (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("ALERTAS")]
        public string ALERTAS { get; set; }  // ALERTAS (máximo de 1000 caracteres)

        [MaxLength(1000)]
        [Column("ALERTASPOS")]
        public string ALERTASPOS { get; set; }  // ALERTASPOS (máximo de 1000 caracteres)

        [MaxLength(50)]
        [Column("SLEXAMESREF_TABELA_COD")]
        public string SLEXAMESREF_TABELA_COD { get; set; }  // SLEXAMESREF_TABELA_COD (máximo de 50 caracteres)

        [MaxLength(255)]
        [Column("SLEXAMESREF_TABELA_EXAME")]
        public string SLEXAMESREF_TABELA_EXAME { get; set; }  // SLEXAMESREF_TABELA_EXAME (máximo de 255 caracteres)

        [MaxLength(50)]
        [Column("SLEXAMESREF_TABELA_CONV")]
        public string SLEXAMESREF_TABELA_CONV { get; set; }  // SLEXAMESREF_TABELA_CONV (máximo de 50 caracteres)

        [MaxLength(100)]
        [Column("SLEXAMESREF_TABELA_PLANO")]
        public string SLEXAMESREF_TABELA_PLANO { get; set; }  // SLEXAMESREF_TABELA_PLANO (máximo de 100 caracteres)

        [MaxLength(50)]
        [Column("SLEXAMESREF_TABELA_AUT")]
        public string SLEXAMESREF_TABELA_AUT { get; set; }  // SLEXAMESREF_TABELA_AUT (máximo de 50 caracteres)

        [Column("SLEXAMESREF_TABELA_VALOR", TypeName = "decimal(18, 2)")]
        public decimal SLEXAMESREF_TABELA_VALOR { get; set; }  // SLEXAMESREF_TABELA_VALOR (valor decimal com 18 dígitos e 2 casas decimais)

        [Column("ESTABILIDADE")]
        public string ESTABILIDADE { get; set; }

        [Column("MATERIAL_APOIO_ID")]
        public int MATERIAL_APOIO_ID { get; set; }

        [Column("EPECIALIDADE_ID")]
        public int EPECIALIDADE_ID { get; set; }
        [Column("SETOR_ID")]
        public int SETOR_ID { get; set; }
    }
}
