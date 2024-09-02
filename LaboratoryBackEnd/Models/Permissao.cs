using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Model
{
    [Table("permissoes")]
    public class Permissao:IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("tipoPermissao_id")] 
        public int? TipoPermissaoId { get; set; }

        [Column("modulo_id")] 
        public int? ModuloId { get; set; }

        [Column("grupoUsuario_id")] 
        public int? GrupoUsuarioId { get; set; }       
    }
}
