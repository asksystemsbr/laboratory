using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Categorias")]
public class Categoria : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [StringLength(255)]
    public string Nome { get; set; }

    public ICollection<SubCategoria> SubCategorias { get; set; } = new List<SubCategoria>();
}
