using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("tecnicos")]
    public class Tecnico : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(20)]
        public string Cpf { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Especialidade { get; set; }

        public ICollection<OrdemServicoTecnico> OrdemServicoTecnicos { get; set; } = new List<OrdemServicoTecnico>();
    }
}
