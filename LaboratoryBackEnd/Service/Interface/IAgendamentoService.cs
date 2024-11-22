using LaboratoryBackEnd.Data.DTO;
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

        Task<string> ValidateCreateBudget(int idAgendamento);
        Task<string> ValidateDeleteAgendamento(int idAgendamento);

        Task Put(AgendamentoCabecalho item);
        Task PutDetalhe(AgendamentoDetalhe item);
        Task PutPagamento(AgendamentoPagamento item);

        Task PutAgendamentoHorarioGerado(AgendamentoHorarioGerado item);
        Task<AgendamentoCabecalho> PostCabecalho(AgendamentoCabecalho item);
        Task<AgendamentoDetalhe> PostDetalhe(AgendamentoDetalhe item);
        Task<AgendamentoPagamento> PostPagamento(AgendamentoPagamento item);

        Task<AgendamentoHorario> PostHorarios(AgendamentoHorarioDto item);

        Task<AgendamentoHorario> GetItemHorario(int id);

        Task<List<AgendamentoHorarioGerado>> GetItemsHorarioGerado(int idAgendamento);

        Task<AgendamentoHorarioGerado> GetHorarioGerado(int id);
        Task<List<AgendamentoHorarioDto>> GetItemsHorarios();

        Task<List<AgendamentoHorarioGerado>> GetItemsHorarioGeradoPreenchidos(int idAgendamento);

        Task<List<AgendamentoHorarioGerado>> GetItemsHorarioGeradoDisponible(int convenioId
            , int planoId
            , int unidadeId
            , int exameId
            , DateTime dataSolicitada);

        Task DeleteAgendamentoHorario(int id);

        Task DeleteAgendamentoHorarioGerado(int idCabecalho);
        Task DeleteAgendamentoHorarioGeradoByDetalhe(int idDetalhe);

        Task DeleteCabecalho(int id);
        Task DeleteDetalhe(int id);
        Task DeletePagamento(int id);

        bool ExistsCabecalho(int id);

        Task RemoveContexAgendamentoHorario(AgendamentoHorario item);
        Task RemoveContexCabecalho(AgendamentoCabecalho item);
        Task RemoveContexDetalhe(AgendamentoDetalhe item);
        Task RemoveContexPagamento(AgendamentoPagamento item);
    }
}