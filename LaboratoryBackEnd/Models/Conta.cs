using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("contas")]
public class Contas : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [StringLength(255)]
    [Column("conta")]
    public string ContaNome { get; set; }

    [Column(TypeName = "decimal(10, 3)")]
    public decimal Valor { get; set; }

    [StringLength(255)]
    public string Tipo { get; set; }

    [Column("dt_Vencimento")]
    public DateTime? DtVencimento { get; set; }

    [Column("dt_pgto")]
    public DateTime? DtPgto { get; set; }

    [Column("Cliente_id")]
    public int? ClienteId { get; set; }

    [Column(TypeName = "decimal(19, 3)")]
    public decimal ValorPagoRecebido { get; set; }

    [Column("Fornecedor_id")]
    public int? FornecedorId { get; set; }

    [Column("Categoria_id")]
    public int CategoriaId { get; set; }

    [Column("SubCategoria_id")]
    public int SubCategoriaId { get; set; }

    [Column("formapagamento_id")]
    public int FormaPagamentoId { get; set; }

    [Column("numcheque")]
    [StringLength(255)]
    public string NumCheque { get; set; }

    [Column("transferencia")]
    public int Transferencia { get; set; }

    // Relacionamentos
    [ForeignKey("ClienteId")]
    public Cliente Cliente { get; set; }

    [ForeignKey("FornecedorId")]
    public Fornecedor Fornecedor { get; set; }

    [ForeignKey("CategoriaId")]
    public ContasCategorias Categoria { get; set; }

    [ForeignKey("SubCategoriaId")]
    public SubCategoria SubCategoria { get; set; }

    [ForeignKey("FormaPagamentoId")]
    public MetodosPagamento MetodosPagamento { get; set; }
}
