public class OrdemServicoServico
{
    public int OsServicoId { get; set; }
    public int OsId { get; set; }
    public int ServicoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal PrecoTotal { get; set; }

    public OrdemDeServico OrdemDeServico { get; set; }
    public Servico Servico { get; set; }
}
