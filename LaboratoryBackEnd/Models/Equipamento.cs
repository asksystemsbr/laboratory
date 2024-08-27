public class Equipamento
{
    public int EquipamentoId { get; set; }
    public string NomeEquipamento { get; set; }
    public string Descricao { get; set; }
    public string NumeroSerie { get; set; }
    public DateTime DataAquisicao { get; set; }

    public ICollection<OrdemServicoEquipamento> OrdemServicoEquipamentos { get; set; }
}
