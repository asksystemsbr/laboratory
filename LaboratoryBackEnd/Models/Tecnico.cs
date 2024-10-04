using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LaboratoryBackEnd.Models
{
    [Table("tecnicos")]
    public class Tecnico : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tecnico_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nome")]
        public string Nome { get; set; }

        [MaxLength(20)]
        [Column("cpf")]
        public string? Cpf { get; set; }

        [MaxLength(20)]
        [Column("telefone")]
        public string? Telefone { get; set; }  

        [MaxLength(100)]
        [Column("email")]
        public string? Email { get; set; }  

        [MaxLength(255)]
        [Column("especialidade")]
        public string? Especialidade { get; set; } 

        public ICollection<OrdemServicoTecnico> OrdemServicoTecnicos { get; set; } = new List<OrdemServicoTecnico>();
    }
}