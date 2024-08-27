public class OrdemServicoExame
{
    public int OsExameId { get; set; }
    public int OsId { get; set; }
    public int ExameId { get; set; }
    public int StatusExameId { get; set; }
    public decimal Preco { get; set; }
    public DateTime? DataEntrega { get; set; }
    public string TermoAutorizacao { get; set; }

    public OrdemDeServico OrdemDeServico { get; set; }
    public Exame Exame { get; set; }
    public StatusExame StatusExame { get; set; }
}
