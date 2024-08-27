using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Servicos")]
public class Servico : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    [MaxLength(255)]
    public string NomeServico { get; set; }

    public string DescricaoServico { get; set; }

    [Required]
    public decimal Preco { get; set; }

    public ICollection<OrdemServicoServico> OrdemServicoServicos { get; set; } = new List<OrdemServicoServico>();
}
