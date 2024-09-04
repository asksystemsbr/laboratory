using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("status_cliente")]
    public class StatusCliente : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("status_cliente_id")]
        public int ID { get; set; }

        [Column("descricao")]
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}
