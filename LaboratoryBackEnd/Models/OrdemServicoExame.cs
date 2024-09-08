using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("ordem_servico_exames")]
    public class OrdemServicoExame : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("os_exame_id")]
        public int ID { get; set; }

        [Required]
        [Column("os_id")]
        public int OsId { get; set; }

        [Required]
        [Column("exame_id")]
        public int ExameId { get; set; }

        [Required]
        [Column("status_exame_id")]
        public int StatusExameId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        [Column("data_entrega")]
        public DateTime? DataEntrega { get; set; }

        [Column("termo_autorizacao", TypeName = "text")]
        public string TermoAutorizacao { get; set; }

        [ForeignKey("OsId")]
        public virtual OrdemDeServico OrdemDeServico { get; set; }

        [ForeignKey("ExameId")]
        public virtual Exame Exame { get; set; }

        [ForeignKey("StatusExameId")]
        public virtual StatusExame StatusExame { get; set; }
    }
}
