using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("empresas_categorias")]
    public class EmpresaCatagoria:IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [StringLength(255)]
        [Column("descricao")]
        public string? Descricao { get; set; }  // Campo opcional
    }
}
