using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Data.DTO
{
    public class AgendamentoCompletoDto
    {
        public AgendamentoCabecalho AgendamentoCabecalho { get; set; }
        public List<AgendamentoDetalheDto> AgendamentoDetalhe { get; set; }
        public List<AgendamentoPagamento> AgendamentoPagamento { get; set; }
    }
}
