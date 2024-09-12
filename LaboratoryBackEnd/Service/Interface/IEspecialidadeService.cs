using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<Especialidade>> GetItems();
        Task<Especialidade> GetItem(int id);
        Task Put(Especialidade item);
        Task<Especialidade> Post(Especialidade item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Especialidade item);
    }
}