using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaboratoryBackEnd.Data.Interface;

namespace LaboratoryBackEnd.Models
{
    [Table("estoque")]
    public class Estoque : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("estoque_id")]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Produto")]
        [Column("produto_id")]
        public int ProdutoId { get; set; }

        [Required]
        [Column("quantidade_disponivel")]
        public int QuantidadeDisponivel { get; set; }

        [StringLength(100)]
        [Column("localizacao")]
        public string? Localizacao { get; set; }

        // Propriedade de navegação para o produto relacionado
        //public virtual Produto Produto { get; set; }
    }
}
