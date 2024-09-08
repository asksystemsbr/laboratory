using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IServicoService
    {
        Task<IEnumerable<Servico>> GetItems();
        Task<Servico> GetItem(int id);
        Task Put(Servico item);
        Task<Servico> Post(Servico item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Servico item);
        Task<int> GetLasdOrOne();
    }
}