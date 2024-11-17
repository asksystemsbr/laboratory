using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<AgendamentoCabecalho>> GetItemsCabecalho();
        Task<IEnumerable<AgendamentoCabecalho>> GetItemsCabecalhoPedido(); 
        Task<AgendamentoCabecalho> GetItemCabecalho(int id);
        Task<List<AgendamentoDetalhe>> GetItemsDetalhe(int idCabecacalho);
        Task<List<AgendamentoPagamento>> GetItemsPagamentos(int idCabecacalho);

        Task<List<Exame>> GetExamesList(int id);
        Task<List<FormaPagamento>> GetPagamentosList(int id);
        Task<bool> CheckDescontoPermission(int idUsuario);

        Task<string> ValidateCreatePedido(int idOrcamento);
        


        Task Put(AgendamentoCabecalho item);
        Task PutDetalhe(AgendamentoDetalhe item);
        Task PutPagamento(AgendamentoPagamento item);

        Task<AgendamentoCabecalho> PostCabecalho(AgendamentoCabecalho item);
        Task<AgendamentoDetalhe> PostDetalhe(AgendamentoDetalhe item);
        Task<AgendamentoPagamento> PostPagamento(AgendamentoPagamento item);

        Task DeleteCabecalho(int id);
        Task DeleteDetalhe(int id);
        Task DeletePagamento(int id);

        bool ExistsCabecalho(int id);
        Task RemoveContexCabecalho(AgendamentoCabecalho item);
        Task RemoveContexDetalhe(AgendamentoDetalhe item);
        Task RemoveContexPagamento(AgendamentoPagamento item);
    }
}