using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IOperationLogService
    {
        Task<IEnumerable<OperationLog>> GetItems();
        Task<OperationLog> GetItem(int id);
        Task Put(OperationLog item);
        Task<OperationLog> Post(OperationLog item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(OperationLog item);
        Task<int> GetLasdOrOne();
    }
}