using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Pagamentos")]
public class Pagamento : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    public int OsId { get; set; }

    [Required]
    public decimal ValorTotal { get; set; }

    [Required]
    public DateTime DataPagamento { get; set; }

    [Required]
    public int MetodoPagamentoId { get; set; }

    [Required]
    public int StatusPagamentoId { get; set; }

    [ForeignKey("OsId")]
    public OrdemDeServico OrdemDeServico { get; set; }

    [ForeignKey("MetodoPagamentoId")]
    public MetodosPagamento MetodosPagamento { get; set; }

    [ForeignKey("StatusPagamentoId")]
    public StatusPagamento StatusPagamento { get; set; }
}
