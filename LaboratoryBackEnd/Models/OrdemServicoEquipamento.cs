public class OrdemServicoEquipamento
{
    public int OsEquipamentoId { get; set; }
    public int OsId { get; set; }
    public int EquipamentoId { get; set; }
    public DateTime DataUtilizacao { get; set; }

    public OrdemDeServico OrdemDeServico { get; set; }
    public Equipamento Equipamento { get; set; }
}
