public class Usuario
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public bool Ativo { get; set; }

    public ICollection<UsuarioRecepcao> UsuariosRecepcoes { get; set; }
}