using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Status_Pagamento")]
public class StatusPagamento : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    [MaxLength(50)]
    public string Descricao { get; set; }

    public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
