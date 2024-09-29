using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LaboratoryBackEnd.Data.Interface;

[Table("enderecos")]
public class Endereco:IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("endereco_id")]
    public int ID { get; set; }

    [Required]
    [StringLength(10)]
    [Column("cep")]
    public string Cep { get; set; }

    [Required]
    [StringLength(255)]
    [Column("logradouro")]
    public string Rua { get; set; }

    [StringLength(255)]
    [Column("complemento")]
    public string? Complemento { get; set; }

    [StringLength(20)]
    [Column("numero")]
    public string? Numero { get; set; }

    [Required]
    [StringLength(255)]
    [Column("bairro")]
    public string Bairro { get; set; }

    [Required]
    [StringLength(100)]
    [Column("localidade")]
    public string Cidade { get; set; }

    [Required]
    [StringLength(2)]
    [Column("uf")]
    public string Uf { get; set; }

    [StringLength(2)]
    [Column("ibge")]
    public string? ibge { get; set; }

    [StringLength(2)]
    [Column("gia")]
    public string? gia { get; set; }

    [StringLength(2)]
    [Column("ddd")]
    public string? ddd { get; set; }

    [StringLength(2)]
    [Column("siafi")]
    public string? siafi { get; set; }

    [StringLength(2)]
    [Column("tipo_endereco")]
    public string? tipo_endereco { get; set; }
}