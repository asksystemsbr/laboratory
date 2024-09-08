using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IExameService
    {
        Task<IEnumerable<Exame>> GetItems();
        Task<Exame> GetItem(int id);
        Task Put(Exame item);
        Task<Exame> Post(Exame item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Exame item);
        Task<int> GetLasdOrOne();
    }
}