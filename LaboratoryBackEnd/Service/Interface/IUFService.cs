using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IUFService
    {
        Task<IEnumerable<UF>> GetItems();
        Task<UF > GetItem(int id);
        Task Put(UF item);
        Task<UF> Post(UF item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(UF item);
    }
}