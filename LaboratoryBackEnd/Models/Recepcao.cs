using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("recepcoes")]
    public class Recepcao : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("recepcao_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nome_recepcao")]
        public string NomeRecepcao { get; set; }

        [Column("endereco_id")]
        public int EnderecoId { get; set; }

        // Propriedade de navegação opcional
        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }

        public ICollection<UsuarioRecepcao> UsuariosRecepcoes { get; set; } = new List<UsuarioRecepcao>();
    }
}