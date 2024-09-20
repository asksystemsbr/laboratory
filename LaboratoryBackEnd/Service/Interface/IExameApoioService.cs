using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IExameApoioService
    {
        Task<IEnumerable<ExameApoio>> GetItems();
        Task<ExameApoio> GetItem(int id);
        Task Put(ExameApoio item);
        Task<ExameApoio> Post(ExameApoio item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(ExameApoio item);
        Task<int> GetLasdOrOne();
    }
}