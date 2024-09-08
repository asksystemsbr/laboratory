using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IFornecedorService
    {
        Task<IEnumerable<Fornecedor>> GetItems();
        Task<Fornecedor> GetItem(int id);
        Task Put(Fornecedor item);
        Task<Fornecedor> Post(Fornecedor item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Fornecedor item);
        Task<int> GetLasdOrOne();
    }
}
