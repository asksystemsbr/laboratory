using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("recepcao_convenio_planos")]
    public class RecepcaoConvenioPlano : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("recepcao_id")]
        public int RecepcaoId { get; set; }

        [Column("convenio_id")]
        public int? ConvenioId { get; set; }

        [Column("plano_id")]
        public int? PlanoId { get; set; }

        [ForeignKey("RecepcaoId")]
        public virtual Recepcao Recepcao { get; set; }

        [ForeignKey("ConvenioId")]
        public virtual Convenio Convenio { get; set; }

        [ForeignKey("PlanoId")]
        public virtual Plano Plano { get; set; }
    }
}