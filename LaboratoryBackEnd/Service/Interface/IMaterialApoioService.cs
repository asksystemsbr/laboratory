using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IMaterialApoioService
    {
        Task<IEnumerable<MaterialApoio>> GetItems();
        Task<MaterialApoio> GetItem(int id);
        Task Put(MaterialApoio item);
        Task<MaterialApoio> Post(MaterialApoio item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(MaterialApoio item);
        Task<int> GetLasdOrOne();
    }
}