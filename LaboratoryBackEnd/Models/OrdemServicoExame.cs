using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Ordem_Servico_Exames")]
public class OrdemServicoExame : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    public int OsId { get; set; }

    [Required]
    public int ExameId { get; set; }

    [Required]
    public int StatusExameId { get; set; }

    [Required]
    public decimal Preco { get; set; }

    public DateTime? DataEntrega { get; set; }

    public string TermoAutorizacao { get; set; }

    [ForeignKey("OsId")]
    public OrdemDeServico OrdemDeServico { get; set; }

    [ForeignKey("ExameId")]
    public Exame Exame { get; set; }

    [ForeignKey("StatusExameId")]
    public StatusExame StatusExame { get; set; }
}
