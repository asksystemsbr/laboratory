using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("usuarios_recepcoes")]
    public class UsuarioRecepcao : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("usuario_recepcao_id")]
        public int ID { get; set; }

        [Column("usuario_id")]
        public int? UsuarioId { get; set; }  // Permite nulo

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [Column("recepcao_id")]
        public int? RecepcaoId { get; set; }  // Permite nulo

        [ForeignKey("RecepcaoId")]
        public virtual Recepcao Recepcao { get; set; }
    }
}