using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ILaboratorioApoioExameApoioService
    {
        Task<IEnumerable<LaboratorioApoioExameApoio>> GetItems();
        Task<LaboratorioApoioExameApoio> GetItem(int id);
        Task Put(LaboratorioApoioExameApoio item);
        Task<LaboratorioApoioExameApoio> Post(LaboratorioApoioExameApoio item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(LaboratorioApoioExameApoio item);
        Task DeleteByLaboratorio(int id);
        Task<List<LaboratorioApoioExameApoio>> GetItemByLaboratorio(int id);
        Task<List<ExameApoio>> GetExameApoioItemByLaboratorio(int laboratorioApoioId);
    }
}