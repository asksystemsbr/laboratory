using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ISubCategoriaService
    {
        Task<IEnumerable<SubCategoria>> GetItems();
        Task<SubCategoria> GetItem(int id);
        Task Put(SubCategoria item);
        Task<SubCategoria> Post(SubCategoria item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(SubCategoria item);
        Task<int> GetLasdOrOne();
    }
}