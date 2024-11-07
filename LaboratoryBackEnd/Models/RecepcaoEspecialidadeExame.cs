using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("recepcao_especialidade_exames")]
    public class RecepcaoEspecialidadeExame : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("recepcao_id")]
        public int RecepcaoId { get; set; }

        [Column("especialidade_id")]
        public int EspecialidadeId { get; set; }

        [Column("exame_id")]
        public int? ExameId { get; set; }

        [NotMapped]
        public List<int>? ExamesId { get; set; } // IDs dos exames selecionados
    }
}
