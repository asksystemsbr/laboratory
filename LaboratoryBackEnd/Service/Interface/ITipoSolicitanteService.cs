using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ITipoSolicitanteService
    {
        Task<IEnumerable<TipoSolicitante>> GetItems();
        Task<TipoSolicitante> GetItem(int id);
        Task Put(TipoSolicitante item);
        Task<TipoSolicitante> Post(TipoSolicitante item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(TipoSolicitante item);
    }
}