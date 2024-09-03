using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

[Table("Clientes")]
public class Cliente : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("cliente_id")]
    public int ID { get; set; }

    [StringLength(255)]
    public string Nome { get; set; }

    [Column("cpf_cnpj"), StringLength(20)]
    public string CpfCnpj { get; set; }

    [StringLength(255)]
    public string Endereco { get; set; }

    [StringLength(20)]
    public string Telefone { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    [Column("sitaucao_id")]
    public int SituacaoID { get; set; }

    public DateTime DATA_CADASTRO { get; set; }

    public ICollection<Contas> Contas { get; set; } = new List<Contas>();
}
