using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoCabecalho>> GetItemsCabecalho();
        Task<IEnumerable<PedidoCabecalho>> GetItemsCabecalhoPedido(); 
        Task<PedidoCabecalho> GetItemCabecalho(int id);
        Task<List<PedidoDetalhe>> GetItemsDetalhe(int idCabecacalho);
        Task<List<PedidoPagamento>> GetItemsPagamentos(int idCabecacalho);

        Task<List<Exame>> GetExamesList(int id);
        Task<List<FormaPagamento>> GetPagamentosList(int id);
        Task<bool> CheckDescontoPermission(int idUsuario);

        Task<string> ValidateCreatePedido(int idOrcamento);
        


        Task Put(PedidoCabecalho item);
        Task PutDetalhe(PedidoDetalhe item);
        Task PutPagamento(PedidoPagamento item);

        Task<PedidoCabecalho> PostCabecalho(PedidoCabecalho item);
        Task<PedidoDetalhe> PostDetalhe(PedidoDetalhe item);
        Task<PedidoPagamento> PostPagamento(PedidoPagamento item);

        Task DeleteCabecalho(int id);
        Task DeleteDetalhe(int id);
        Task DeletePagamento(int id);

        bool ExistsCabecalho(int id);
        Task RemoveContexCabecalho(PedidoCabecalho item);
        Task RemoveContexDetalhe(PedidoDetalhe item);
        Task RemoveContexPagamento(PedidoPagamento item);
    }
}