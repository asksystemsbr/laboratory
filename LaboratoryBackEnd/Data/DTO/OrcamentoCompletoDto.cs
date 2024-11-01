using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Data.DTO
{
    public class OrcamentoCompletoDto
    {
        public OrcamentoCabecalho OrcamentoCabecalho { get; set; }
        public List<OrcamentoDetalhe> OrcamentoDetalhe { get; set; }
        public List<OrcamentoPagamento> OrcamentoPagamento { get; set; }
    }
}
