﻿using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("clientes")]
public class Cliente : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("cliente_id")]
    public int ID { get; set; }

    [Required]
    [StringLength(255)]
    [Column("nome")]
    public string Nome { get; set; }

    [StringLength(20)]
    [Column("cpf_cnpj")]
    public string? CpfCnpj { get; set; }

    [Required] 
    [Column("endereco_id")]
    public int? EnderecoId { get; set; }

    [StringLength(20)]
    [Column("telefone")]
    public string? Telefone { get; set; }


    [StringLength(20)]
    [Column("telefone_celular")]
    public string? TelefoneCelular { get; set; }
    

    [Required]
    [StringLength(100)]
    [Column("email")]
    public string? Email { get; set; }

    [Required]
    [Column("situacao_id")]
    public int SituacaoId { get; set; }

    [Required]
    [Column("data_cadastro")]
    public DateTime DataCadastro { get; set; }

    [StringLength(10)]
    [Column("sexo")]
    public string Sexo { get; set; }

    [Column("nascimento")]
    public DateTime? Nascimento { get; set; }

    [Column("convenio_id")]
    public int? ConvenioId { get; set; }

    [Column("plano_id")]
    public int? PlanoId { get; set; }

    [StringLength(20)]
    [Column("rg")]
    public string? RG { get; set; }

    [StringLength(255)]
    [Column("razao_social")]
    public string? RazaoSocial { get; set; }

    [StringLength(255)]
    [Column("senha")]
    public string? Senha { get; set; }

    [StringLength(20)]
    [Column("ie")]
    public string? IE { get; set; }

    [StringLength(20)]
    [Column("im")]
    public string? IM { get; set; }

    [StringLength(255)]
    [Column("nome_responsavel")]
    public string? NomeResponsavel { get; set; }

    [StringLength(20)]
    [Column("cpf_responsavel")]
    public string? CpfResponsavel { get; set; }

    [StringLength(20)]
    [Column("telefone_responsavel")]
    public string? TelefoneResponsavel { get; set; }

    [Column("nome_social", TypeName = "varchar(max)")]
    public string? NomeSocial { get; set; }

    [Column("nome_mae", TypeName = "varchar(max)")]
    public string? NomeMae { get; set; }

    [Column("foto", TypeName = "varbinary(max)")]
    public byte[]? Foto { get; set; }

    [Column("profissao", TypeName = "varchar(max)")]
    public string? Profissao { get; set; }

    [Column("matricula", TypeName = "varchar(max)")]
    public string? Matricula { get; set; }

    [Column("validade_matricula", TypeName = "date")]
    public DateTime? ValidadeMatricula { get; set; }

    [Column("titular_convenio", TypeName = "varchar(max)")]
    public string? TitularConvenio { get; set; }

    // Propriedade de navegação opcional
    [ForeignKey("EnderecoId")]
    public virtual Endereco? Endereco { get; set; }
}