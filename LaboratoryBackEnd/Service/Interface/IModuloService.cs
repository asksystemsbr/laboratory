using LaboratoryBackEnd.Model;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IModuloService
    {
        Task<IEnumerable<Modulo>> GetItems();
        Task<Modulo> GetItem(int id);
        Task Put(Modulo item);
        Task<Modulo> Post(Modulo item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Modulo item);
        Task<int> GetLasdOrOne();
    }
}