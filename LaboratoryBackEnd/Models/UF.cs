using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("uf")]
    public class UF : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nome_uf")]
        public string NomeUf { get; set; }

        [Required]
        [Column("codigo_ibge")]
        public int CodigoIbge { get; set; }

        [Required]
        [MaxLength(2)]
        [Column("sigla_uf")]
        public string SiglaUf { get; set; }
    }
}