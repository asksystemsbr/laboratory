using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IRotinaExameService
    {
        Task<IEnumerable<RotinaExame>> GetItems();
        Task<RotinaExame> GetItem(int id);
        Task Put(RotinaExame item);
        Task<RotinaExame> Post(RotinaExame item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(RotinaExame item);
    }
}