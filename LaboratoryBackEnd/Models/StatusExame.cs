public class StatusExame
{
    public int StatusExameId { get; set; }
    public string Descricao { get; set; }

    public ICollection<OrdemServicoExame> OrdemServicoExames { get; set; }
}
