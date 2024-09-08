using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IStatusExameService
    {
        Task<IEnumerable<StatusExame>> GetItems();
        Task<StatusExame> GetItem(int id);
        Task Put(StatusExame item);
        Task<StatusExame> Post(StatusExame item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(StatusExame item);
        Task<int> GetLasdOrOne();
    }
}