using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("ordem_servico_equipamentos")]
    public class OrdemServicoEquipamento : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("os_equipamento_id")]
        public int ID { get; set; }

        [Required]
        [Column("os_id")]
        public int OsId { get; set; }

        [Required]
        [Column("equipamento_id")]
        public int EquipamentoId { get; set; }

        [Required]
        [Column("data_utilizacao")]
        public DateTime DataUtilizacao { get; set; }

        [ForeignKey("OsId")]
        public virtual OrdemDeServico OrdemDeServico { get; set; }

        [ForeignKey("EquipamentoId")]
        public virtual Equipamento Equipamento { get; set; }
    }
}
