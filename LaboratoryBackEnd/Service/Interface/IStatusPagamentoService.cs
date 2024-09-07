using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IStatusPagamentoService
    {
        Task<IEnumerable<StatusPagamento>> GetItems();
        Task<StatusPagamento> GetItem(int id);
        Task Put(StatusPagamento item);
        Task<StatusPagamento> Post(StatusPagamento item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(StatusPagamento item);
        Task<int> GetLasdOrOne();
    }
}