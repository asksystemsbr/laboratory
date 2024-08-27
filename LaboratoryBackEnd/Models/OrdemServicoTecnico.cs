using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Ordem_Servico_Tecnicos")]
public class OrdemServicoTecnico : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    public int OsId { get; set; }

    [Required]
    public int TecnicoId { get; set; }

    [Required]
    public DateTime DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    [ForeignKey("OsId")]
    public OrdemDeServico OrdemDeServico { get; set; }

    [ForeignKey("TecnicoId")]
    public Tecnico Tecnico { get; set; }
}
