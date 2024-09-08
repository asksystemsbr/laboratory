using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IModuloService
    {
        Task<IEnumerable<Modulos>> GetItems();
        Task<Modulos> GetItem(int id);
        Task Put(Modulos item);
        Task<Modulos> Post(Modulos item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Modulos item);
        Task<int> GetLasdOrOne();
    }
}