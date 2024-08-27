public class Recepcao
{
    public int RecepcaoId { get; set; }
    public string NomeRecepcao { get; set; }

    public ICollection<UsuarioRecepcao> UsuariosRecepcoes { get; set; }
}