using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("status_os")]
    public class StatusOs : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("status_os_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("descricao")]
        public string Descricao { get; set; }

        public ICollection<OrdemDeServico> OrdensDeServico { get; set; } = new List<OrdemDeServico>();
    }
}
