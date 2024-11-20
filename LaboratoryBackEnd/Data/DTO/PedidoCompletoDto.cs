using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Data.DTO
{
    public class PedidoCompletoDto
    {
        public PedidoCabecalho PedidoCabecalho { get; set; }
        public List<PedidoDetalhe> PedidoDetalhe { get; set; }
        public List<PedidoPagamento> PedidoPagamento { get; set; }
    }
}
