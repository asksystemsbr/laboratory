using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaboratoryBackEnd.Data.Interface;

[Table("enderecos")]
public class Endereco : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("endereco_id")]
    public int ID { get; set; }

    [StringLength(9)]
    [Column("cep")]
    public string? Cep { get; set; }

    [StringLength(255)]
    [Column("logradouro")]
    public string? Rua { get; set; }

    [StringLength(255)]
    [Column("complemento")]
    public string? Complemento { get; set; }

    [StringLength(255)]
    [Column("numero")]
    public string? Numero { get; set; }

    [StringLength(255)]
    [Column("bairro")]
    public string? Bairro { get; set; }

    [StringLength(255)]
    [Column("localidade")]
    public string? Cidade { get; set; }

    [StringLength(2)]
    [Column("uf")]
    public string? Uf { get; set; }

    [StringLength(7)]
    [Column("ibge")]
    public string? ibge { get; set; }

    [StringLength(4)]
    [Column("gia")]
    public string? gia { get; set; }

    [StringLength(2)]
    [Column("ddd")]
    public string? ddd { get; set; }

    [StringLength(5)]
    [Column("siafi")]
    public string? siafi { get; set; }

    [StringLength(20)]
    [Column("tipo_endereco")]
    public string? tipo_endereco { get; set; }
}