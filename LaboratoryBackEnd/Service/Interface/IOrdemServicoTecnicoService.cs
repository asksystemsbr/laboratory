using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IOrdemServicoTecnicoService
    {
        Task<IEnumerable<OrdemServicoTecnico>> GetItems();
        Task<OrdemServicoTecnico> GetItem(int id);
        Task Put(OrdemServicoTecnico item);
        Task<OrdemServicoTecnico> Post(OrdemServicoTecnico item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(OrdemServicoTecnico item);
        Task<int> GetLasdOrOne();
    }
}