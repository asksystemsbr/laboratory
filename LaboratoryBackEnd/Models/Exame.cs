using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Exames")]
public class Exame : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    [MaxLength(255)]
    public string NomeExame { get; set; }

    public string Descricao { get; set; }

    [Required]
    public int QuantidadeTubos { get; set; }

    [Required]
    [MaxLength(255)]
    public string ModoArmazenamento { get; set; }

    [Required]
    [MaxLength(255)]
    public string ModoRetirada { get; set; }

    public ICollection<OrdemServicoExame> OrdemServicoExames { get; set; } = new List<OrdemServicoExame>();
}
