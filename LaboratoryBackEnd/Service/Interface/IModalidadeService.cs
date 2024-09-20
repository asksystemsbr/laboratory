using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IModalidadeService
    {
        Task<IEnumerable<Modalidade>> GetItems();
        Task<Modalidade> GetItem(int id);
        Task Put(Modalidade item);
        Task<Modalidade> Post(Modalidade item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Modalidade item);
    }
}