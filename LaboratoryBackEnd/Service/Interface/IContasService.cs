using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IContasService
    {
        Task<IEnumerable<Contas>> GetItems();
        Task<Contas> GetItem(int id);
        Task Put(Contas item);
        Task<Contas> Post(Contas item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Contas item);
        Task<int> GetLasdOrOne();
    }
}
