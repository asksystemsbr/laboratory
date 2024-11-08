using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IConvenioService
    {
        Task<IEnumerable<Convenio>> GetItems();
        Task<Convenio> GetItem(int id);
        Task<Convenio> GetItemByCodigo(string codigo);
        Task<IEnumerable<Convenio>> GetConveniosByRecepcao(int codigo);
        Task<Convenio> GetConvenioByCodigoRecepcao(string codigoConvenio, int recepcaoId);
        Task Put(Convenio item);
        Task<Convenio> Post(Convenio item);
        Task Delete(int id,int idEndereco);
        bool Exists(int id);
        Task RemoveContex(Convenio item);
    }
}