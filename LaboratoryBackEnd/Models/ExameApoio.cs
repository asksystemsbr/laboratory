using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("exames_apoio")]
    public class ExameApoio:IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("exame_apoio_id")]
        public int ID { get; set; }

        [Column("codigo_exame", TypeName = "text")]
        public string CodigoExame { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nome_exame")]
        public string NomeExame { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("apoio")]
        public string Apoio { get; set; }

        [Required]
        [Column("dias")]
        public int Dias { get; set; }

        [Required]
        [Column("especialidade_exame_id")]
        public int EspecialidadeExameId { get; set; }

        [Required]
        [Column("setor_exame_id")]
        public int SetorExameId { get; set; }

        [Required]
        [Column("valor_atual", TypeName = "decimal(10,2)")]
        public decimal ValorAtual { get; set; } = 0;
    }
}
