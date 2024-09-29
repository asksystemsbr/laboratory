using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("solicitante")]
    public class Solicitante : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [StringLength(255)]
        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("crm")]
        public string? Crm { get; set; }

        [Column("uf_crm")]
        public int? UfCrm { get; set; }

        [Column("cpf")]
        public string? Cpf { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("telefone")]
        public string? Telefone { get; set; }

        [Column("tipo_solicitante_id")]
        public int? TipoSolicitanteId { get; set; }
    }
}
