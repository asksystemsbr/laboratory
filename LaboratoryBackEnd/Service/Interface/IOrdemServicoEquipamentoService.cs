using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IOrdemServicoEquipamentoService
    {
        Task<IEnumerable<OrdemServicoEquipamento>> GetItems();
        Task<OrdemServicoEquipamento> GetItem(int id);
        Task Put(OrdemServicoEquipamento item);
        Task<OrdemServicoEquipamento> Post(OrdemServicoEquipamento item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(OrdemServicoEquipamento item);
        Task<int> GetLasdOrOne();
    }
}