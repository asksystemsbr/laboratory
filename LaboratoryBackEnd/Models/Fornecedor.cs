using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Fornecedores")]
public class Fornecedor : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [StringLength(255)]
    public string Nome { get; set; }

    [StringLength(20)]
    public string CpfCnpj { get; set; }

    [StringLength(255)]
    public string Endereco { get; set; }

    [StringLength(20)]
    public string Telefone { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    // Relacionamentos
    public ICollection<Contas> Contas { get; set; } = new List<Contas>();
}
