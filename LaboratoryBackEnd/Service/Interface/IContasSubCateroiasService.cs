using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IContasSubCategoriasService
    {
        Task<IEnumerable<ContasSubCategorias>> GetItems();
        Task<ContasSubCategorias> GetItem(int id);
        Task Put(ContasSubCategorias item);
        Task<ContasSubCategorias> Post(ContasSubCategorias item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(ContasSubCategorias item);
        Task<int> GetLasdOrOne();
    }
}
