using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ISetorService
    {
        Task<IEnumerable<Setor>> GetItems();
        Task<Setor> GetItem(int id);
        Task Put(Setor item);
        Task<Setor> Post(Setor item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Setor item);
    }
}