using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Usuarios_Recepcoes")]
public class UsuarioRecepcao : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    public int UsuarioId { get; set; }

    [Required]
    public int RecepcaoId { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; }

    [ForeignKey("RecepcaoId")]
    public Recepcao Recepcao { get; set; }
}
