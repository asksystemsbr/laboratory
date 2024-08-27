public class UsuarioRecepcao
{
    public int UsuarioRecepcaoId { get; set; }
    public int UsuarioId { get; set; }
    public int RecepcaoId { get; set; }

    public Usuario Usuario { get; set; }
    public Recepcao Recepcao { get; set; }
}