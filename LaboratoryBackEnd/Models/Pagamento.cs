public class Pagamento
{
    public int PagamentoId { get; set; }
    public int OsId { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataPagamento { get; set; }
    public int MetodoPagamentoId { get; set; }
    public int StatusPagamentoId { get; set; }

    public OrdemDeServico OrdemDeServico { get; set; }
    public MetodoPagamento MetodoPagamento { get; set; }
    public StatusPagamento StatusPagamento { get; set; }
}