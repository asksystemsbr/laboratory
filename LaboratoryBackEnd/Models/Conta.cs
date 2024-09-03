using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    [Table("contas")]
    public class Contas : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [StringLength(255)]
        [Column("conta")]
        public string Conta { get; set; }

        [Column("valor", TypeName = "decimal(10, 3)")]
        public decimal? Valor { get; set; }

        [StringLength(255)]
        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("data_vencimento")]
        public DateTime? DataVencimento { get; set; }

        [Column("data_pagamento")]
        public DateTime? DataPagamento { get; set; }

        [Column("imovel_id")]
        public int? ImovelId { get; set; }

        [Column("valor_pago_recebido", TypeName = "decimal(19, 3)")]
        public decimal? ValorPagoRecebido { get; set; }

        [Column("fornecedor_id")]
        public int? FornecedorId { get; set; }

        [Column("categoria_id")]
        public int? CategoriaId { get; set; }

        [Column("subcategoria_id")]
        public int? SubCategoriaId { get; set; }

        [Column("metodo_pagamento_id")]
        public int? MetodoPagamentoId { get; set; }

        [StringLength(255)]
        [Column("numero_cheque")]
        public string NumeroCheque { get; set; }

        [Column("cliente_id")]
        public int? ClienteId { get; set; }
    }

