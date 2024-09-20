using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IMetodoExameService
    {
        Task<IEnumerable<MetodoExame>> GetItems();
        Task<MetodoExame> GetItem(int id);
        Task Put(MetodoExame item);
        Task<MetodoExame> Post(MetodoExame item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(MetodoExame item);
    }
}