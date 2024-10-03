using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("convenio")]
    public class Convenio : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [StringLength(255)]
        [Column("descricao")]
        public string? Descricao { get; set; } // Campo opcional

        [Column("endereco_id")]
        public int EnderecoId { get; set; } // Campo opcional

        // Propriedade de navegação opcional
        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }
    }
}