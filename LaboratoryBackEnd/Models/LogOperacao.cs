using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("log_auditoria")]
    public class LogOperacao : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("data_hora", TypeName = "datetime2(7)")]
        public DateTime DataHora { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("tipo_acao")]
        public string TipoAcao { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nome_tabela")]
        public string NomeTabela { get; set; }

        [Column("dados", TypeName = "nvarchar(max)")]
        public string Dados { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("usuario_id")]
        public string UsuarioId { get; set; }
    }
}
