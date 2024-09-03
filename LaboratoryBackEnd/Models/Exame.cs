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
        [Column("exame_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nome_exame")]
        public string NomeExame { get; set; }

        [Column("descricao", TypeName = "text")]
        public string Descricao { get; set; }

        [Required]
        [Column("quantidade_tubos")]
        public int QuantidadeTubos { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("modo_armazenamento")]
        public string ModoArmazenamento { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("modo_retirada")]
        public string ModoRetirada { get; set; }
    }
}
