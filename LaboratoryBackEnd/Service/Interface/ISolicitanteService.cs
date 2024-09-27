using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ISolicitanteService
    {
        Task<IEnumerable<Solicitante>> GetItems();
        Task<Solicitante> GetItem(int id);
        Task Put(Solicitante item);
        Task<Solicitante> Post(Solicitante item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Solicitante item);
    }
}