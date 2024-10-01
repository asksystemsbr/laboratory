using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("laboratorio_apoio_materiais")]
    public class LaboratorioApoioMateriais : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("laboratorio_apoio_id")]
        public int LaboratorioApoioId { get; set; }

        [Required]
        [Column("material_apoio_id")]
        public int MaterialApoioId { get; set; }

        // Propriedades de navegação
        [ForeignKey("LaboratorioApoioId")]
        public LaboratorioApoio LaboratorioApoio { get; set; }

        [ForeignKey("MaterialApoioId")]
        public MaterialApoio MaterialApoio { get; set; }
    }
}