using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IRecepcaoService
    {
        Task<IEnumerable<Recepcao>> GetItems();
        Task<Recepcao> GetItem(int id);
        Task Put(Recepcao item);
        Task<Recepcao> Post(Recepcao item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Recepcao item);
        Task<int> GetLasdOrOne();
    }
}