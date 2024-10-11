using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IPlanoService
    {
        Task<IEnumerable<Plano>> GetItems();
        Task<Plano> GetItem(int id);
        Task<Plano?> GetItemByConvenio(int id);
        Task<List<Plano>> GetListByConvenio(int id);
        Task Put(Plano item);
        Task<Plano> Post(Plano item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Plano item);
    }
}