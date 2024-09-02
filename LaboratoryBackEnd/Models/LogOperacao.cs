

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Model
{
    [Table("log_operacoes")]
    public class LogOperacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime data_hora { get; set; }
        public string tipo_operacao { get; set; }
        public string detalhes { get; set; }
        public bool sucesso { get; set; }
        public string mensagem_erro { get; set; }
    }
}
