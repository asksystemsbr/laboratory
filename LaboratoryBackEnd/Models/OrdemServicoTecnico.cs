public class OrdemServicoTecnico
{
    public int OsTecnicoId { get; set; }
    public int OsId { get; set; }
    public int TecnicoId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }

    public OrdemDeServico OrdemDeServico { get; set; }
    public Tecnico Tecnico { get; set; }
}
