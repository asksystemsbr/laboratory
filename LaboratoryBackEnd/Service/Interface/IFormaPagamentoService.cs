using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IFormaPagamentoService
    {
        Task<IEnumerable<FormaPagamento>> GetItems();
        Task<FormaPagamento> GetItem(int id);
        Task Put(FormaPagamento item);
        Task<FormaPagamento> Post(FormaPagamento item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(FormaPagamento item);
        Task<int> GetLasdOrOne();
    }
}
