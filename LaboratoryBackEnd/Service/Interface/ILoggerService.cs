using LaboratoryBackEnd.Models;
using System.Security.Claims;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface ILoggerService
    {
        Task LogAuditAsync(AuditLog log);
        Task LogOperationAsync(OperationLog log);

        Task LogError<T>(string operationType, T contextType, ClaimsPrincipal user, Exception ex);
    }
}
