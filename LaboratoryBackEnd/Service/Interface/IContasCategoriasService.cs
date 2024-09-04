using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IContasCategoriasService
    {
        Task<IEnumerable<ContasCategorias>> GetItems();
        Task<ContasCategorias> GetItem(int id);
        Task Put(ContasCategorias item);
        Task<ContasCategorias> Post(ContasCategorias item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(ContasCategorias item);
        Task<int> GetLasdOrOne();
    }
}
