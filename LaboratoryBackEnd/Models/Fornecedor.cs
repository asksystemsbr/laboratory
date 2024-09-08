using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("fornecedores")]
    public class Fornecedor : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("fornecedor_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nome_fornecedor")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("cnpj")]
        public string CpfCnpj { get; set; }

        [MaxLength(255)]
        [Column("endereco")]
        public string Endereco { get; set; }

        [MaxLength(20)]
        [Column("telefone")]
        public string Telefone { get; set; }

        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; }
    }
}
