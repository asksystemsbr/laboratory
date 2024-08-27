public class Servico
{
    public int ServicoId { get; set; }
    public string NomeServico { get; set; }
    public string DescricaoServico { get; set; }
    public decimal Preco { get; set; }

    public ICollection<OrdemServicoServico> OrdemServicoServicos { get; set; }
}
