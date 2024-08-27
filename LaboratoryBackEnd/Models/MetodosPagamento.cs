using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Metodos_Pagamento")]
public class MetodosPagamento : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [StringLength(255)]
    public string Nome { get; set; }

    public ICollection<Contas> Contas { get; set; } = new List<Contas>();
}