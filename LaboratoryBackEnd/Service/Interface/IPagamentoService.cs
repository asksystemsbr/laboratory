using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IPagamentoService
    {
        Task<IEnumerable<Pagamento>> GetItems();
        Task<Pagamento> GetItem(int id);
        Task Put(Pagamento item);
        Task<Pagamento> Post(Pagamento item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Pagamento item);
        Task<int> GetLasdOrOne();
    }
}
