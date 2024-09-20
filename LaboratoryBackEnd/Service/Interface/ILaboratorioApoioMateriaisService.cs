using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ILaboratorioApoioMateriaisService
    {
        Task<IEnumerable<LaboratorioApoioMateriais>> GetItems();
        Task<LaboratorioApoioMateriais> GetItem(int id);
        Task Put(LaboratorioApoioMateriais item);
        Task<LaboratorioApoioMateriais> Post(LaboratorioApoioMateriais item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(LaboratorioApoioMateriais item);
        Task DeleteByLaboratorio(int id);
        Task<List<LaboratorioApoioMateriais>> GetItemByLaboratorio(int id);

        Task<List<MaterialApoio>> GetMaterialItemByLaboratorio(int id);
    }
}