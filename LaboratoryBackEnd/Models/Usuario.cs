using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("usuarios")]
    public class Usuario : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public bool? Ativo { get; set; } // Nullable bit field
    }
}
