using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaboratoryBackEnd.Models
{
    [Table("tipo_permissao")]
    public class TipoPermissao : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [StringLength(255)]
        [Column("descricao")]
        public string? Descricao { get; set; }
    }
}