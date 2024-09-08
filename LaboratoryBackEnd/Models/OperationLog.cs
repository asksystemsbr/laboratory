using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("log_operacoes")]
    public class OperationLog : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("data_hora")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Column("tipo_operacao")]
        [StringLength(255)]
        public string OperationType { get; set; }

        [Column("detalhes")]
        public string Details { get; set; }

        [Required]
        [Column("sucesso")]
        public bool IsSuccess { get; set; }

        [Column("mensagem_erro")]
        public string ErrorMessage { get; set; }
    }
}
