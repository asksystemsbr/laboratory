using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("ordem_servico_tecnicos")]
    public class OrdemServicoTecnico : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("os_tecnico_id")]
        public int ID { get; set; }

        [Required]
        [Column("os_id")]
        public int OsId { get; set; }

        [Required]
        [Column("tecnico_id")]
        public int TecnicoId { get; set; }

        [Required]
        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime? DataFim { get; set; }

        [ForeignKey("OsId")]
        public virtual OrdemDeServico OrdemDeServico { get; set; }

        [ForeignKey("TecnicoId")]
        public virtual Tecnico Tecnico { get; set; }
    }
}
