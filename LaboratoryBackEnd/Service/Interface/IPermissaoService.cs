using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IPermissaoService
    {
        Task<IEnumerable<Permissao>> GetItems();
        Task<Permissao> GetItem(int id);
        Task Put(Permissao item);
        Task<Permissao> Post(Permissao item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Permissao item);
        Task<int> GetLasdOrOne();
    }
}