using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaboratoryBackEnd.Models
{
    [Table("tabela_preco")]
    public class TabelaPreco : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }  // Permite nulo
    }
}