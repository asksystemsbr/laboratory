using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IMetodosPagamentoService
    {
        Task<IEnumerable<MetodosPagamento>> GetItems();
        Task<MetodosPagamento> GetItem(int id);
        Task Put(MetodosPagamento item);
        Task<MetodosPagamento> Post(MetodosPagamento item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(MetodosPagamento item);
        Task<int> GetLasdOrOne();
    }
}