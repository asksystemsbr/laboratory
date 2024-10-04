using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("sub_categorias")]
    public class SubCategoria : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("subcategoria_id")]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("Categoria")]
        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        public ContasCategorias Categoria { get; set; }
    }
}