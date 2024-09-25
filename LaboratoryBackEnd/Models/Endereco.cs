using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("enderecos")]
public class Endereco
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
    [Column("rua")]
    public string Rua { get; set; }

    [StringLength(20)]
    [Column("numero")]
    public string Numero { get; set; }

    [StringLength(255)]
    [Column("complemento")]
    public string Complemento { get; set; }

    [Required]
    [StringLength(255)]
    [Column("bairro")]
    public string Bairro { get; set; }

    [Required]
    [StringLength(100)]
    [Column("cidade")]
    public string Cidade { get; set; }

    [Required]
    [StringLength(2)]
    [Column("uf")]
    public string Uf { get; set; }

    // Propriedade de navegação para associar clientes ao endereço
    public virtual ICollection<Cliente> Clientes { get; set; }
}