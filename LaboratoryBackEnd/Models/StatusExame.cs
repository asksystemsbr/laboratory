using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("status_exames")]
    public class StatusExame : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("status_exame_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("descricao")]
        public string Descricao { get; set; }

        public ICollection<OrdemServicoExame> OrdemServicoExames { get; set; } = new List<OrdemServicoExame>();
    }
}