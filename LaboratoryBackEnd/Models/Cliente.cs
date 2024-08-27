public class Cliente
{
    public int ClienteId { get; set; }
    public string Nome { get; set; }
    public string CpfCnpj { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public ICollection<OrdemDeServico> OrdensDeServico { get; set; }
}
