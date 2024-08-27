public class Exame
{
    public int ExameId { get; set; }
    public string NomeExame { get; set; }
    public string Descricao { get; set; }
    public int QuantidadeTubos { get; set; }
    public string ModoArmazenamento { get; set; }
    public string ModoRetirada { get; set; }

    public ICollection<OrdemServicoExame> OrdemServicoExames { get; set; }
}
