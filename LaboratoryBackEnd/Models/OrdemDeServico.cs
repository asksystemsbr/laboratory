public class OrdemDeServico
{
    public int OsId { get; set; }
    public int ClienteId { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFechamento { get; set; }
    public int StatusOsId { get; set; }
    public string DescricaoProblema { get; set; }
    public string Observacoes { get; set; }

 
    public Cliente Cliente { get; set; }
    public StatusOs StatusOs { get; set; }
    public ICollection<OrdemServicoExame> OrdemServicoExames { get; set; }
    public ICollection<OrdemServicoServico> OrdemServicoServicos { get; set; }
    public ICollection<OrdemServicoTecnico> OrdemServicoTecnicos { get; set; }
    public ICollection<OrdemServicoEquipamento> OrdemServicoEquipamentos { get; set; }
    public ICollection<Pagamento> Pagamentos { get; set; }
}
