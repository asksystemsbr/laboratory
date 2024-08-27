public class StatusPagamento
{
    public int StatusPagamentoId { get; set; }
    public string Descricao { get; set; }

    public ICollection<Pagamento> Pagamentos { get; set; }
}
