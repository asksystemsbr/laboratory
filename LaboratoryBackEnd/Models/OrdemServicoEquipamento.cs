using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Ordem_Servico_Equipamentos")]
public class OrdemServicoEquipamento : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    public int OsId { get; set; }

    [Required]
    public int EquipamentoId { get; set; }

    [Required]
    public DateTime DataUtilizacao { get; set; }

    [ForeignKey("OsId")]
    public OrdemDeServico OrdemDeServico { get; set; }

    [ForeignKey("EquipamentoId")]
    public Equipamento Equipamento { get; set; }
}
