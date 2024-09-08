using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IOrdemServicoExameService
    {
        Task<IEnumerable<OrdemServicoExame>> GetItems();
        Task<OrdemServicoExame> GetItem(int id);
        Task Put(OrdemServicoExame item);
        Task<OrdemServicoExame> Post(OrdemServicoExame item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(OrdemServicoExame item);
        Task<int> GetLasdOrOne();
    }
}