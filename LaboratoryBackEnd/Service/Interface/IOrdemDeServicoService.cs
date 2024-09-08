using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IOrdemDeServicoService
    {
        Task<IEnumerable<OrdemDeServico>> GetItems();
        Task<OrdemDeServico> GetItem(int id);
        Task Put(OrdemDeServico item);
        Task<OrdemDeServico> Post(OrdemDeServico item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(OrdemDeServico item);
        Task<int> GetLasdOrOne();
    }
}