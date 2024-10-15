using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("laboratorio_apoio")]
    public class LaboratorioApoio : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [MaxLength(255)]
        [Column("nome_laboratorio")]
        public string? NomeLaboratorio { get; set; }  // Permite nulo

        [Column("endereco_id")]
        public int EnderecoId { get; set; } // Campo opcional

        // Propriedade de navegação opcional
        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }

        [MaxLength(255)]
        [Column("url_api")]
        public string? UrlApi { get; set; }  // Permite nulo

        [StringLength(20)]
        [Column("cpf_cnpj")]
        public string CpfCnpj { get; set; }

        [Column("empresa_id")]
        public int? EmpresaId { get; set; }
    }
}