using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IUsuarioRecepcaoService
    {
        Task<IEnumerable<UsuarioRecepcao>> GetItems();
        Task<UsuarioRecepcao> GetItem(int id);
        Task Put(UsuarioRecepcao item);
        Task<UsuarioRecepcao> Post(UsuarioRecepcao item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(UsuarioRecepcao item);
        Task<int> GetLasdOrOne();
    }
}