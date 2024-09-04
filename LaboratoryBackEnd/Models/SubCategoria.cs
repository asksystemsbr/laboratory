using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("SubCategorias")]
public class SubCategoria : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [StringLength(255)]
    public string Nome { get; set; }

    [Required]
    [ForeignKey("Categoria")]
    public int CategoriaId { get; set; }

    public ContasCategorias Categoria { get; set; }
}
