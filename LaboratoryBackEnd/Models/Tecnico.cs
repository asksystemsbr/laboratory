public class Tecnico
{
    public int TecnicoId { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Especialidade { get; set; }

    public ICollection<OrdemServicoTecnico> OrdemServicoTecnicos { get; set; }
}
