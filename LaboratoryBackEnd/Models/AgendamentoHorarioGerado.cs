using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("agendamento_horario_gerado")]
    public class AgendamentoHorarioGerado : IIdentifiable
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("agendamento_horario_Id")]
        public int AgendamentoHorarioId { get; set; } 

        [Column("horario")]
        public DateTime Horario { get; set; } 

        [Column("Status")]
        public string Status { get; set; } 


    }
}
