using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("Servicos")]
    public class Servico : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("servico_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nome_servico")]
        public string NomeServico { get; set; }

        [Column("descricao_servico")]
        public string DescricaoServico { get; set; }

        [Required]
        [Column("preco", TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        public ICollection<OrdemServicoServico> OrdemServicoServicos { get; set; } = new List<OrdemServicoServico>();
    }
}
