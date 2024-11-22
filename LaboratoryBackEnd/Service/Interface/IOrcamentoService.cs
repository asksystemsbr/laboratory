using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IOrcamentoService
    {
        Task<IEnumerable<OrcamentoCabecalho>> GetItemsCabecalho();
        Task<IEnumerable<OrcamentoCabecalho>> GetItemsCabecalhoPedido(); 
        Task<OrcamentoCabecalho> GetItemCabecalho(int id);
        Task<List<OrcamentoDetalhe>> GetItemsDetalhe(int idCabecacalho);
        Task<List<OrcamentoPagamento>> GetItemsPagamentos(int idCabecacalho);

        Task<List<Exame>> GetExamesList(int id);
        Task<List<FormaPagamento>> GetPagamentosList(int id);
        Task<bool> CheckDescontoPermission(int idUsuario);

        Task<string> ValidateCreatePedido(int idOrcamento);
        


        Task Put(OrcamentoCabecalho item);
        Task PutDetalhe(OrcamentoDetalhe item);
        Task PutPagamento(OrcamentoPagamento item);

        Task<OrcamentoCabecalho> PostCabecalho(OrcamentoCabecalho item);
        Task<OrcamentoDetalhe> PostDetalhe(OrcamentoDetalhe item);
        Task<OrcamentoPagamento> PostPagamento(OrcamentoPagamento item);

        Task DeleteCabecalho(int id);
        Task DeleteDetalhe(int id);
        Task DeletePagamento(int id);

        bool ExistsCabecalho(int id);
        Task RemoveContexCabecalho(OrcamentoCabecalho item);
        Task RemoveContexDetalhe(OrcamentoDetalhe item);
        Task RemoveContexPagamento(OrcamentoPagamento item);
    }
}