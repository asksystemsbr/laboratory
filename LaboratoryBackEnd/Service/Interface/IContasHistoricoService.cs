using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IContasHistoricoService
    {
        Task<IEnumerable<ContasHistorico>> GetItems();
        Task<ContasHistorico> GetItem(int id);
        Task Put(ContasHistorico item);
        Task<ContasHistorico> Post(ContasHistorico item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(ContasHistorico item);
        Task<int> GetLasdOrOne();
    }
}
