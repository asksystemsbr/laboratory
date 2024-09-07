using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IAuditLogService
    {
        Task<IEnumerable<AuditLog>> GetItems();
        Task<AuditLog> GetItem(int id);
        Task Put(AuditLog item);
        Task<AuditLog> Post(AuditLog item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(AuditLog item);
        Task<int> GetLasdOrOne();
    }
}
