using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("material_apoio")]
    public class MaterialApoio : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("material_apoio_id")]
        public int ID { get; set; }

        [Column("codigo_material", TypeName = "text")]
        public string? CodigoMaterial { get; set; } 

        [Required]
        [MaxLength(255)]
        [Column("nome_material")]
        public string NomeMaterial { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("material_apoio")]
        public string MaterialApoioDescricao { get; set; }
    }
}