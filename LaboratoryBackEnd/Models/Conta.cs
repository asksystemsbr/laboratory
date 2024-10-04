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
    public decimal? Valor { get; set; }

    [StringLength(255)]
    public string Tipo { get; set; }

    [Column("data_vencimento")]
    public DateTime? DtVencimento { get; set; }

    [Column("data_pagamento")]
    public DateTime? DtPgto { get; set; }

    [Column("Cliente_id")]
    public int? ClienteId { get; set; }

    [Column(TypeName = "decimal(19, 3)")]
    public decimal? ValorPagoRecebido { get; set; }

    [Column("Fornecedor_id")]
    public int? FornecedorId { get; set; }

    [Column("categoria_id")]
    public int? CategoriaId { get; set; }

    [Column("subcategoria_id")]
    public int? SubCategoriaId { get; set; }

    [Column("metodo_pagamento_id")]
    public int? FormaPagamentoId { get; set; }

    [Column("numero_cheque")]
    [StringLength(255)]
    public string NumCheque { get; set; }

    [Column("transferencia")]
    public int Transferencia { get; set; }

    [Column("imovel_id")]
    public int? ImovelId { get; set; }


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
