using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("laboratorio_apoio_exame_apoio")]
    public class LaboratorioApoioExameApoio: IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("laboratorio_apoio_id")]
        public int LaboratorioApoioId { get; set; }

        [Column("exame_apoio_id")]
        public int ExameApoioId { get; set; }
    }
}
