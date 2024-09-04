using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Status_OS")]
public class StatusOs : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    [MaxLength(50)]
    public string Descricao { get; set; }

    public ICollection<OrdemDeServico> OrdensDeServico { get; set; } = new List<OrdemDeServico>();
}
