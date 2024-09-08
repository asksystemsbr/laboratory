using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IStatusClienteService
    {
        Task<IEnumerable<StatusCliente>> GetItems();
        Task<StatusCliente> GetItem(int id);
        Task Put(StatusCliente item);
        Task<StatusCliente> Post(StatusCliente item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(StatusCliente item);
        Task<int> GetLasdOrOne();
    }
}
