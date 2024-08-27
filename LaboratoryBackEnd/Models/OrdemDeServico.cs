using LaboratoryBackEnd.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Ordem_de_servico")]
public class OrdemDeServico : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    public int ClienteId { get; set; }

    [Required]
    public DateTime DataAbertura { get; set; }

    public DateTime? DataFechamento { get; set; }

    [Required]
    public int StatusOsId { get; set; }

    public string DescricaoProblema { get; set; }

    public string Observacoes { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente Cliente { get; set; }

    [ForeignKey("StatusOsId")]
    public StatusOs StatusOs { get; set; }

    public ICollection<OrdemServicoExame> OrdemServicoExames { get; set; } = new List<OrdemServicoExame>();

    public ICollection<OrdemServicoServico> OrdemServicoServicos { get; set; } = new List<OrdemServicoServico>();

    public ICollection<OrdemServicoTecnico> OrdemServicoTecnicos { get; set; } = new List<OrdemServicoTecnico>();

    public ICollection<OrdemServicoEquipamento> OrdemServicoEquipamentos { get; set; } = new List<OrdemServicoEquipamento>();

    public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
