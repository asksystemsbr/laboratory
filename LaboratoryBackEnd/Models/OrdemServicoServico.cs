﻿using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Ordem_Servico_Servicos")]
public class OrdemServicoServico : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    public int OsId { get; set; }

    [Required]
    public int ServicoId { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    [Column("preco_unitario", TypeName = "decimal(10,2)")]
    public decimal PrecoUnitario { get; set; }

    [Required]
    [Column("preco_total", TypeName = "decimal(10,2)")]
    public decimal PrecoTotal { get; set; }

    [ForeignKey("OsId")]
    public OrdemDeServico OrdemDeServico { get; set; }

    [ForeignKey("ServicoId")]
    public Servico Servico { get; set; }
}
