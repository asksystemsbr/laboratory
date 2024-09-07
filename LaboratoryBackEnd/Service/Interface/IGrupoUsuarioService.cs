using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IGrupoUsuarioService
    {
        Task<IEnumerable<GrupoUsuario>> GetItems();
        Task<GrupoUsuario> GetItem(int id);
        Task Put(GrupoUsuario item);
        Task<GrupoUsuario> Post(GrupoUsuario item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(GrupoUsuario item);
        Task<int> GetLasdOrOne();
    }
}
