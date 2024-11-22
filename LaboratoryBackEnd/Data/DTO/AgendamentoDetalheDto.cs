namespace LaboratoryBackEnd.Data.DTO
{
    public class AgendamentoDetalheDto
    {
        public int ID { get; set; }
        public int? AgendamentoId { get; set; }
        public int? ExameId { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataColeta { get; set; }
        public int? HorarioId { get; set; }
        
    }
}
