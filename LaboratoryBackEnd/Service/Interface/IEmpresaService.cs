using LaboratoryBackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IEmpresaService
    {
        Task<IEnumerable<Empresa>> GetItems();
        Task<Empresa> GetItem(int id);
        Task Put(Empresa item);
        Task<Empresa> Post(Empresa item);
        Task Delete(int id, int idEndereco);
        bool Exists(int id);
        Task RemoveContex(Empresa item);
        Task<int> GetLasdOrOne();
    }
}