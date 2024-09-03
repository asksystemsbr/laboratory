using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("log_auditoria")]
    public class AuditLog : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("data_hora")]
        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(255)]
        [Column("tipo_acao")]
        public string ActionType { get; set; }

        [Required]
        [StringLength(255)]
        [Column("nome_tabela")]
        public string TableName { get; set; }

        [Required]
        [Column("dados")]
        public string Data { get; set; }

        [Required]
        [StringLength(255)]
        [Column("usuario_id")]
        public string UserId { get; set; }
    }
}
