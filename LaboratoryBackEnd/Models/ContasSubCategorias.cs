using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("contas_sub_categorias")]
    public class ContasSubCategorias:IIdentifiable
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("descricao")]
        [StringLength(255)]
        public string? Descricao { get; set; }

        [Required]
        [Column("contas_categorias_id")]
        public int ContasCategoriasId { get; set; }

        // Navigation property
        [ForeignKey("ContasCategoriasId")]
        public ContasCategorias ContasCategorias { get; set; }
    }
}
