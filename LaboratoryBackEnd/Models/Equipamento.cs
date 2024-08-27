using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Equipamentos")]
public class Equipamento : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    [MaxLength(255)]
    public string NomeEquipamento { get; set; }

    public string Descricao { get; set; }

    [MaxLength(50)]
    public string NumeroSerie { get; set; }

    public DateTime DataAquisicao { get; set; }

    public ICollection<OrdemServicoEquipamento> OrdemServicoEquipamentos { get; set; } = new List<OrdemServicoEquipamento>();
}