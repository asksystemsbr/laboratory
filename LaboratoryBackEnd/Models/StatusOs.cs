public class StatusOs
{
    public int StatusOsId { get; set; }
    public string Descricao { get; set; }

    public ICollection<OrdemDeServico> OrdensDeServico { get; set; }
}
