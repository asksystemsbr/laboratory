using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ITabelaPrecoService
    {
        Task<IEnumerable<TabelaPreco>> GetItems();
        Task<TabelaPreco> GetItem(int id);
        Task Put(TabelaPreco item);
        Task<TabelaPreco> Post(TabelaPreco item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(TabelaPreco item);
    }
}