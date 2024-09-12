using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ILaboratorioApoioService
    {
        Task<IEnumerable<LaboratorioApoio>> GetItems();
        Task<LaboratorioApoio> GetItem(int id);
        Task Put(LaboratorioApoio item);
        Task<LaboratorioApoio> Post(LaboratorioApoio item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(LaboratorioApoio item);
    }
}