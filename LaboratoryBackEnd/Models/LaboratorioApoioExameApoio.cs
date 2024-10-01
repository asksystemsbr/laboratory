using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("laboratorio_apoio_exame_apoio")]
    public class LaboratorioApoioExameApoio : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("laboratorio_apoio_id")]
        public int LaboratorioApoioId { get; set; }

        [Required]
        [Column("exame_apoio_id")]
        public int ExameApoioId { get; set; }

        // Propriedades de navegação
        [ForeignKey("LaboratorioApoioId")]
        public LaboratorioApoio LaboratorioApoio { get; set; }

        [ForeignKey("ExameApoioId")]
        public ExameApoio ExameApoio { get; set; }
    }
}