using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("Recepcoes")]
    public class Recepcao : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string NomeRecepcao { get; set; }

        public ICollection<UsuarioRecepcao> UsuariosRecepcoes { get; set; } = new List<UsuarioRecepcao>();
    }
}