public class MetodoPagamento
{
    public int MetodoPagamentoId { get; set; }
    public string Descricao { get; set; }

    public ICollection<Pagamento> Pagamentos { get; set; }
}