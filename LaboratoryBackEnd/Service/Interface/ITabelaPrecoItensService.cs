using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ITabelaPrecoItensService
    {
        Task<IEnumerable<TabelaPrecoItens>> GetItems();
        Task<TabelaPrecoItens> GetItem(int id);
        Task Put(TabelaPrecoItens item);
        Task<TabelaPrecoItens> Post(TabelaPrecoItens item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(TabelaPrecoItens item);
    }
}